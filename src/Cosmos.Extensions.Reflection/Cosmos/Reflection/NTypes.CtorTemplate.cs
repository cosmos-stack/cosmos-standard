#if !NET451 && !NET452

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using BTFindTree;
using Natasha.CSharp;
using Natasha.Error.Model;

/*
 * Author: LanX
 * 2020.01.03
 */

namespace Cosmos.Reflection
{
    internal class CtorTemplate
    {
        public readonly Dictionary<string, List<(ConstructorInfo, ParameterInfo)>> Cache;

        // public readonly Dictionary<string, string> RealNameMapping;
        public readonly ConstructorInfo[] Ctors;
        public readonly Dictionary<ConstructorInfo, int> CtorsMappings;
        public readonly Func<IEnumerable<CtorArgDescriptor>, CtorMatchedResult> GetIndex;
        private readonly int _defaultCtorIndex;
        public readonly Func<object[], object>[] Initor;

        private CtorTemplate(Type type)
        {
            CtorsMappings = new Dictionary<ConstructorInfo, int>();
            Cache = new Dictionary<string, List<(ConstructorInfo, ParameterInfo)>>();
            Ctors = type.GetConstructors();
            Initor = new Func<object[], object>[Ctors.Length];

            var maxParametersCount = 0;

            for (var i = 0; i < Ctors.Length; i++)
            {
                CtorsMappings[Ctors[i]] = i;
                var parameters = Ctors[i].GetParameters();
                if (parameters.Length > maxParametersCount)
                {
                    maxParametersCount = parameters.Length;
                }

                if (parameters.Length == 0)
                {
                    _defaultCtorIndex = i;
                }

                var pairs = new ParameterInfo[parameters.Length];

                for (var j = 0; j < parameters.Length; j++)
                {
                    pairs[parameters[j].Position] = parameters[j];
                    var key = parameters[j].ParameterType.Name + parameters[j].Name;
                    if (!Cache.ContainsKey(key))
                    {
                        Cache[key] = new List<(ConstructorInfo, ParameterInfo)>();
                    }

                    Cache[key].Add((Ctors[i], parameters[j]));
                }

                var parameterScript = new StringBuilder();
                for (int j = 0; j < pairs.Length; j += 1)
                {
                    parameterScript.AppendLine(@$"{pairs[j].Name}:arg[{j}]==null?default:({pairs[j].ParameterType.GetDevelopName()})arg[{j}]");
                    if (j != pairs.Length - 1)
                    {
                        parameterScript.Append(",");
                    }
                }

                Initor[i] = NDelegate.RandomDomain().Func<object[], object>($"return new {type.GetDevelopName()}({parameterScript});");
            }

            var tempCache = new Dictionary<string, string>();
            var script = new StringBuilder();
            script.Append($@"
                if(arg == default || arg.Count() == 0)
                {{
                    return new CtorMatchedResult(null,{_defaultCtorIndex});
                }}
                int[] index = new int[{Ctors.Length}];
                object[][] values = new object[{Ctors.Length}][];
                for(int i=0;i<{Ctors.Length};i+=1)
                {{
                    values[i] = new object[{maxParametersCount}];
                }}
                foreach(var item in arg){{
                    string temp = item.Type.Name + item.Name;
");
            foreach (var item in Cache)
            {
                var builder = new StringBuilder();
                foreach (var ctor in item.Value)
                {
                    builder.AppendLine($"index[{CtorsMappings[ctor.Item1]}]+=1;");
                    builder.AppendLine($"values[{CtorsMappings[ctor.Item1]}][{ctor.Item2.Position}]=item.Value;");
                }

                tempCache[item.Key] = builder.ToString();
            }

            script.AppendLine(BTFTemplate.GetPrecisionPointBTFScript(tempCache, "temp"));
            script.AppendLine("}");
            script.AppendLine(@"
                int maxValue = 0;
                int maxIndex = 0;
                for(int i=0;i<index.Length;i++){
                    if(maxValue<index[i])
                    {
                        maxValue = index[i];
                        maxIndex = i;
                    }
                }
                return new CtorMatchedResult(values[maxIndex],maxIndex);
");
            GetIndex = NDelegate
               .RandomDomain(c => c.SyntaxErrorBehavior = ExceptionBehavior.Throw)
               .UnsafeFunc<IEnumerable<CtorArgDescriptor>, CtorMatchedResult>(script.ToString());
        }

        public object GetCtor(IEnumerable<CtorArgDescriptor> test)
        {
            var result = GetIndex(test);
            return Initor[result.Index](result.Values);
        }

        public static CtorTemplate Create<T>() => new CtorTemplate(typeof(T));

        public static CtorTemplate Create(Type type) => new CtorTemplate(type);
    }
}

#endif