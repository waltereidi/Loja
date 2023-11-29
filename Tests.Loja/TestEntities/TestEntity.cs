
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace Tests.Loja.TestEntities
{
    
    public class TestEntity
    {
        [Attributes.TestClass("Test1")]
        public string param { get; set; }

        [Attributes.TestClass("Test2")]
        public string param2 { get; set; }
        [Attributes.TestClass("tes4")]
        public string param3 { get; set; }

        [StringLength(20, MinimumLength = 4, ErrorMessage = "Must be at least 4 characters long.")]
        public string param4 { get; set; }



        public List<string> GetAttribute()
        {

            Assembly? assembly = Assembly.GetEntryAssembly();

            IEnumerable<Attribute> attributes = assembly.GetCustomAttributes();


            Type types = this.GetType();
            List<string> Return = new List<string>();
               
                MemberInfo[] members = types.GetMembers();

                foreach (MemberInfo member in members)
                {
                    IOrderedEnumerable<Attributes.TestClassAttribute> coders =
                      member.GetCustomAttributes<Attributes.TestClassAttribute>()
                      .OrderByDescending(c => c.LastModified);

                IOrderedEnumerable<StringLengthAttribute> coders2 =
                  member.GetCustomAttributes<StringLengthAttribute>()
                  .OrderByDescending(c => c.ErrorMessage);
                foreach (Attributes.TestClassAttribute coder in coders)
                {
                    Return.Add(coder.value);
                    
                    if (coder.ValidateLength(13, this.GetType().GetProperty(member.Name)?.GetValue(this).ToString()))
                    {
                        throw new Exception("sdsd");
                    }
                    
                }
                foreach (StringLengthAttribute coder in coders2)
                    {
                        Return.Add(coder.ErrorMessage);
                    }
                    
                }
            return Return;
            
            
        }
    }
}
