using System.Reflection;
using System.Reflection.Emit;

namespace CustomMocking;

public class Mock
{
    public static T CreateMockObject<T>()
    {
        var assemblyName = new AssemblyName("DynamicAssembly");
        var assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly
        (
            assemblyName,
            AssemblyBuilderAccess.Run
        );

        var modelBuilder = assemblyBuilder.DefineDynamicModule(name: "DynamicAssembly");

        var typeBuilder = modelBuilder.DefineType
        (
            name: "PriceService",
            attr: TypeAttributes.Public
        );

        var interfaceType = typeof(T);

        typeBuilder.AddInterfaceImplementation(interfaceType);

        var methodBuilder = typeBuilder.DefineMethod
        (
            name: "CalculatePrice",
            attributes: MethodAttributes.Public | MethodAttributes.Virtual,
            typeof(int),
            Type.EmptyTypes
        );

        var iLGenerator = methodBuilder.GetILGenerator();
        iLGenerator.Emit(opcode: OpCodes.Ldc_I4, 90);
        iLGenerator.Emit(opcode: OpCodes.Ret);

        var implementationType = typeBuilder.CreateType();

        var instance = Activator.CreateInstance(implementationType);

        return instance is null ? throw new Exception(message: "Instance is null") : (T)instance;
    }
}