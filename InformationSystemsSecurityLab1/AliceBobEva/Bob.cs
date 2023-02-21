using System;

namespace InformationSystemsSecurityLab1.AliceBobEva
{
    internal class Bob : BaseUser
    {
        public Bob()
        {
            Name = "Bob";
        }

        public override void SetKey(BaseUser user = null)
        {
            if (user.Name == "Alice")
            {
                var random = new Random();
                int key = random.Next();
                user.Key = key;
                Key = key;
            }
        }
    }
}
