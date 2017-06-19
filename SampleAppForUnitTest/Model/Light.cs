
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAppForUnitTest.Model
{
    public interface ILight
    {
        Boolean Power { get; }
    }

    public class Light : ILight
    {
        public Light(Boolean power)
        {
            this.power = power;
        }

        public Boolean Power
        {
            get { return this.power; }
        }

        private Boolean power;
    }
}
