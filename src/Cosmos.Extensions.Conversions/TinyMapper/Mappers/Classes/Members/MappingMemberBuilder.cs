using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TinyMapper.Bindings;
using TinyMapper.Core.DataStructures;
using TinyMapper.Core.Extensions;

namespace TinyMapper.Mappers.Classes.Members {
    internal sealed class MappingMemberBuilder {
        private readonly IMapperBuilderConfig _config;

        public MappingMemberBuilder(IMapperBuilderConfig config) {
            _config = config;
        }

        public List<MappingMemberPath> Build(TypePair typePair) {
            return ParseMappingTypes(typePair);
        }

        private static MemberInfo[] GetPublicMembers(Type type) {
            var flags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static;
            var properties = type.GetProperties(flags);
            var fields = type.GetFields(flags);
            var members = new MemberInfo[properties.Length + fields.Length];
            properties.CopyTo(members, 0);
            fields.CopyTo(members, properties.Length);
            return members;
        }

        private static List<MemberInfo> GetSourceMembers(Type sourceType) {
            var result = new List<MemberInfo>();

            var members = GetPublicMembers(sourceType);
            foreach (var member in members) {
                if (member.IsProperty()) {
                    var method = ((PropertyInfo) member).GetGetMethod();
                    if (method.IsNull()) {
                        continue;
                    }
                }

                result.Add(member);
            }

            return result;
        }

        private static List<MemberInfo> GetTargetMembers(Type targetType) {
            var result = new List<MemberInfo>();

            var members = GetPublicMembers(targetType);
            foreach (var member in members) {
                if (member.IsProperty()) {
                    var method = ((PropertyInfo) member).GetSetMethod();
                    if (method.IsNull() || method.GetParameters().Length != 1) {
                        continue;
                    }
                }

                result.Add(member);
            }

            return result;
        }

        private List<string> GetTargetName(
            Option<BindingConfig> bindingConfig,
            TypePair typePair,
            MemberInfo sourceMember,
            Dictionary<string, string> targetBindings) {
            Option<List<string>> targetName;
            var binds = sourceMember.GetAttributes<BindAttribute>();
            var bind = binds.FirstOrDefault(x => x.TargetType.IsNull());
            if (bind.IsNull()) {
                bind = binds.FirstOrDefault(x => typePair.Target.IsAssignableFrom(x.TargetType));
            }

            if (bind.IsNotNull()) {
                // ReSharper disable once PossibleNullReferenceException
                targetName = new Option<List<string>>(new List<string> {bind.MemberName});
            } else {
                targetName = bindingConfig.Map(x => x.GetBindField(sourceMember.Name));
                if (targetName.HasNoValue) {
                    if (targetBindings.TryGetValue(sourceMember.Name, out var targetMemberName)) {
                        targetName = new Option<List<string>>(new List<string> {targetMemberName});
                    } else {
                        targetName = new Option<List<string>>(new List<string> {sourceMember.Name});
                    }
                }
            }

            return targetName.Value;
        }

        private Dictionary<string, string> GetTest(TypePair typePair, List<MemberInfo> targetMembers) {
            var result = new Dictionary<string, string>();
            foreach (MemberInfo member in targetMembers) {
                var bindAttribute = member.GetAttribute<BindAttribute>();
                if (bindAttribute.HasNoValue) {
                    continue;
                }

                if (bindAttribute.Value.TargetType.IsNull() || typePair.Source.IsAssignableFrom(bindAttribute.Value.TargetType)) {
                    result[bindAttribute.Value.MemberName] = member.Name;
                }
            }

            return result;
        }

        private bool IsIgnore(Option<BindingConfig> bindingConfig, TypePair typePair, MemberInfo sourceMember) {
            var ignores = sourceMember.GetAttributes<IgnoreAttribute>();
            if (ignores.Any(x => x.TargetType.IsNull())) {
                return true;
            }

            if (ignores.FirstOrDefault(x => typePair.Target.IsAssignableFrom(x.TargetType)).IsNotNull()) {
                return true;
            }

            return bindingConfig.Map(x => x.IsIgnoreSourceField(sourceMember.Name)).Value;
        }

        private List<MemberInfo> GetSourceMemberPath(List<string> fieldPath, Type sourceType) {
            var result = new List<MemberInfo>();
            var dummyType = sourceType;
            foreach (var path in fieldPath) {
                var member = GetSourceMembers(dummyType).Single(x => string.Equals(x.Name, path, StringComparison.Ordinal));
                result.Add(member);
                dummyType = member.GetMemberType();
            }

            return result;
        }

        private List<MappingMemberPath> ParseMappingTypes(TypePair typePair) {
            var result = new List<MappingMemberPath>();

            var sourceMembers = GetSourceMembers(typePair.Source);
            var targetMembers = GetTargetMembers(typePair.Target);

            var targetBindings = GetTest(typePair, targetMembers);

            var bindingConfig = _config.GetBindingConfig(typePair);

            foreach (var sourceMember in sourceMembers) {
                if (IsIgnore(bindingConfig, typePair, sourceMember)) {
                    continue;
                }

                var targetNames = GetTargetName(bindingConfig, typePair, sourceMember, targetBindings);

                foreach (var targetName in targetNames) {
                    var targetMember = targetMembers.FirstOrDefault(x => _config.NameMatching(targetName, x.Name));
                    if (targetMember.IsNull()) {
                        result.AddRange(GetBindMappingMemberPath(typePair, bindingConfig, sourceMember));
                        continue;
                    }

                    var concreteBindingType = bindingConfig.Map(x => x.GetBindType(targetName));
                    if (concreteBindingType.HasValue) {
                        var mappingTypePair = new TypePair(sourceMember.GetMemberType(), concreteBindingType.Value);
                        result.Add(new MappingMemberPath(sourceMember, targetMember, mappingTypePair));
                    } else {
                        result.Add(new MappingMemberPath(sourceMember, targetMember));
                    }

                    result.AddRange(GetBindMappingMemberPath(typePair, bindingConfig, sourceMember));
                }

            }

            return result;
        }

        private List<MappingMemberPath> GetBindMappingMemberPath(TypePair typePair, Option<BindingConfig> bindingConfig, MemberInfo sourceMember) {
            var result = new List<MappingMemberPath>();

            var bindFieldPath = bindingConfig.Map(x => x.GetBindFieldPath(sourceMember.Name));

            if (bindFieldPath.HasValue) {
                foreach (var item in bindFieldPath.Value) {
                    var sourceMemberPath = GetSourceMemberPath(item.SourcePath, typePair.Source);
                    var targetMemberPath = GetSourceMemberPath(item.TargetPath, typePair.Target);
                    result.Add(new MappingMemberPath(sourceMemberPath, targetMemberPath));

                }
            }

            return result;
        }
    }
}