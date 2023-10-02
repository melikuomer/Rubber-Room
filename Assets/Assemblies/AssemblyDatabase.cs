

using System;
using Abilities;

using System.Reflection;
using System.Linq;

using System.Collections.Generic;
using UnityEngine;

using objectMap= System.Collections.Generic.Dictionary<string, object>;
using Unity.VisualScripting;

public static class AssemblyDatabase {
        
        public static readonly Assembly assembly = Assembly.GetExecutingAssembly();

        public static readonly objectMap AssemblyMap = CreateMap(GetInterfacesInNamespace(namespaceType: typeof(AbilityConfig)));


      

    static private objectMap EnumerableToDictionary (IEnumerable<Type> types ){
        objectMap typeMap = new ();
        foreach (var type in types){

            typeMap[type.Name] = type;
           
        }

        return typeMap;
    }

    
   

    static private IEnumerable<Type> GetAssembliesOfType ( Type selectedType){
       
        return  assembly.GetTypes().Where(type => selectedType.IsAssignableFrom(type) && type.IsClass );
    }


    static public string [] GetAsssemblyNamesOfType ( Type selectedType){
        return GetAssembliesOfType( selectedType).Select(type => type.Name).ToArray();
    }

    static public objectMap GetMapForType (Type selectedType){

        throw new NotImplementedException();
    }

    static public void DebugText (Type type){
        var x = GetAsssemblyNamesOfType(type);
        //Debug.Log("ahmet" + x[0]);
    }

    public static Type[] GetInterfacesInNamespace( Type namespaceType)
    {
        // Load the assembly.

        // Get the type of the namespace.
        var types = assembly.GetTypes().Where(type => (type.Namespace == namespaceType.Namespace) && type.IsInterface ).ToArray();
        // Get all the interfaces that are defined in the namespace.
        
        // Return the array of interfaces.
        return types;
    }

    private static objectMap CreateMap(Type[] types){
        var map = new objectMap();
        foreach (var type in types)
        {
            var innerMap = new objectMap();
            var TypeNames = GetAssembliesOfType(type);
            foreach (var innerType in TypeNames ){
                innerMap.Add(innerType.Name, innerType);

            } 
            map.Add(type.Name, innerMap);

        }

        return map;
    }

    public static objectMap GetObjectMap(Type type){

        var x = (objectMap)AssemblyMap.GetValueOrDefault(type.Name); 
        return x;
    }

    public static void temp (){
        var x = GetObjectMap(typeof(AbilityConfig));
        x.Keys.ToArray();
    }

}