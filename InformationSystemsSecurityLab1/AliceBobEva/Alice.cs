using System;
using System.Runtime.CompilerServices;

namespace InformationSystemsSecurityLab1.AliceBobEva
{
    internal class Alice : BaseUser
    {
        public Alice()
        {
            Name = "Alice";
        }

        public override void SetKey(BaseUser user = null)
        {
            if(user.Name == "Bob")
            {
                var random = new Random();
                int key = random.Next();
                user.Key = key;
                Key = key;
            }
        }
    }
}
