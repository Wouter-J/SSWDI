using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AS_BusinessRules
{
    /// <summary>
    /// Business rule 02
    /// Non Sterilised Animals can't be added to Animals of the opposite gender in the same location
    /// </summary>
    public class BusinessRule2
    {
        [Fact]
        public void AnimalWithProperValuesShouldBeAdded() { }

        [Fact]
        public void AnimalWithFaultyValuesShouldFail() { }
    }
}
