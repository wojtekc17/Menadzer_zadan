using System;

namespace WpfApplication5
{
    internal class Activated
    {
        public Activated()
        {
        }

        public static implicit operator EventHandler(Activated v)
        {
            throw new NotImplementedException();
        }
    }
}