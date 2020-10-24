using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AS_BusinessRules
{
    /// <summary>
    /// Business Rule 03
    /// Treatments can't be added if the Animal is not placed yet.
    /// Nor can treatments be added after Animal passing
    /// </summary>
    public class BusinessRule3
    {
        [Fact]
        public void ProperTreatmentCanBeAddedToAnimal() { }

        [Fact]
        public void DeceasedAnimalsCantHaveTreatments() { }

        [Fact]
        public void AnimalsWithoutPlacementCantHaveTreatments() { }
    }
}
