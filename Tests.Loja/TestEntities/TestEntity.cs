using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tests.Loja.Attributes;
using System.Reflection; // Assembly


namespace Tests.Loja.TestEntities
{
    public class TestEntity
    {
        [Attributes.TestClassAttribute("Test")]
        public string param { get; set; }

        public List<string> GetAttribute()
        {

            Assembly? assembly = Assembly.GetEntryAssembly();

            IEnumerable<Attribute> attributes = assembly.GetCustomAttributes();
            
          
            Type[] types = assembly.GetTypes();
            List<string> Return = new List<string>();
            foreach (Type type in types)
            {
               
                MemberInfo[] members = type.GetMembers();

                foreach (MemberInfo member in members)
                {
                    IOrderedEnumerable<Attributes.TestClassAttribute> coders =
                      member.GetCustomAttributes<Attributes.TestClassAttribute>()
                      .OrderByDescending(c => c.LastModified);

                    
                    foreach (Attributes.TestClassAttribute coder in coders)
                    {
                        Return.Add(coder.value);
                    }
                }
            }
            return Return;
            
            
        }
    }
}
