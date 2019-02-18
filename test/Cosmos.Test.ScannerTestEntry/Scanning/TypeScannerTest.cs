using System;
using System.Collections.Generic;
using System.Linq;
using Cosmos.Test.ScannerTest0;
using Cosmos.Test.ScannerTestEntry.Extensions;
using Xunit;

namespace Cosmos.Test.ScannerTestEntry.Scanning
{
    public class TypeScannerTest
    {
        public class TypeScanner2 : TypeScanner
        {
            public TypeScanner2() { }
            protected override Func<Type, bool> TypeFilter() =>
                t => t.IsPublic && typeof(IAlexinea).IsAssignableFrom(t);
        }

        [Fact]
        public void ScanNormalType()
        {
            using (var scanner = new TypeScanner2())
            {
                var types = scanner.Scan().ToList();
                Assert.Equal(15, types.Count);
            }
        }




        public class AbstractTypeScanner2 : TypeScanner
        {
            public AbstractTypeScanner2() { }
            protected override Func<Type, bool> TypeFilter() =>
                t => t.IsPublic && t.IsAbstract && t.IsClass && typeof(IAlexinea).IsAssignableFrom(t);
        }

        [Fact]
        public void ScanAbstractType()
        {
            using (var scanner = new AbstractTypeScanner2())
            {
                var types = scanner.Scan().ToList();
                Assert.Equal(4, types.Count);
            }
        }




        public class GenericTypeScanner2 : TypeScanner
        {
            public GenericTypeScanner2() { }
            protected override Func<Type, bool> TypeFilter() =>
                t => t.IsPublic && t.IsGenericType && typeof(GenericRiku<>).IsAssignableFrom(t);
        }

        [Fact]
        public void ScanGenericType()
        {
            using (var scanner = new GenericTypeScanner2())
            {
                var types = scanner.Scan().ToList();
                Assert.Single(types);
            }
        }




        public class AbstractGenericTypeScanner2 : TypeScanner
        {
            public AbstractGenericTypeScanner2() { }
            protected override Func<Type, bool> TypeFilter() =>
                t => t.IsPublic && t.IsAbstract && t.IsGenericType && typeof(AbstractGenericRiku<>).IsAssignableFrom(t);
        }

        [Fact]
        public void ScanAbstractGenericType()
        {
            using (var scanner = new AbstractGenericTypeScanner2())
            {
                var types = scanner.Scan().ToList();
                Assert.Single(types);
            }
        }

        


        public class TypeScanner3 : TypeScanner
        {
            public TypeScanner3() { }

            protected override Func<Type, bool> TypeFilter() =>
                t => t.IsPublic && t.IsClass && typeof(IAlexinea).IsAssignableFrom(t);
        }

        [Fact]
        public void ScanNormalTypeAndInterfaceFilter()
        {
            using (var scanner = new TypeScanner3())
            {
                var types = scanner.Scan().ToList();
                Assert.Equal(14, types.Count);
            }
        }




        public class FilterAndTypeScanner3 : TypeScanner
        {
            private readonly GenericRikuMapHelper _helper;
            public FilterAndTypeScanner3()
            {
                _helper = new GenericRikuMapHelper();
                BaseRikuType = typeof(ComponentRiku);
                BindingEntityTypes = GetGenericRikuBodyTypes();
            }

            public Type BaseRikuType { get; }

            public List<Type> BindingEntityTypes { get; }

            protected override Func<Type, bool> TypeFilter() =>
                t => t.IsPublic && t.IsClass && typeof(IMap).IsAssignableFrom(t) &&
                     _helper.IsMatchedEntityMappingRule(t, BindingEntityTypes);

            private List<Type> GetGenericRikuBodyTypes()
            {
                return BaseRikuType.GetProperties()
                    .Select(t => t.PropertyType)
                    .Where(t => t.IsGenericType)
                    .Select(s => s.GetGenericArguments()[0])
                    .ToList();
            }
        }

        [Fact]
        public void ScanNormalTypeAndInterfaceFilter2()
        {
            using (var scanner = new FilterAndTypeScanner3())
            {
                var types = scanner.Scan().ToList();
                Assert.Equal(10, types.Count);
            }
        }




        public void ScanAbstractTypeAndInterfaceFilter() { }
        public void ScanAbstractTypeAndInterfaceFilter2() { }
        public void ScanGenericTypeAndInterfaceFilter() { }
        public void ScanGenericTypeAndInterfaceFilter2() { }
        public void ScanAbstractGenericTypeAndInterfaceFilter() { }
        public void ScanAbstractGenericTypeAndInterfaceFilter2() { }

    }
}
