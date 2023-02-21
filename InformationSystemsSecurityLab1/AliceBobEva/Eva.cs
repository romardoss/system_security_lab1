using System;

namespace InformationSystemsSecurityLab1.AliceBobEva
{
    internal class Eva : BaseUser
    {
        public Eva()
        {
            Name = "Eva";
        }

        public override void SetKey(BaseUser user = null)
        {
            var random = new Random();
            Key = random.Next();
        }
    }
}
