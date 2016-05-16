using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace Extra_Labb_1_Test
{

    public class EmailValidator
    {
        public bool IsEmailValid(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }

            return false;
        }
    }

    [TestFixture]
    class EmailValidatorTest
    {
        public void EmailIsInvalidIf_Emty()
        {
            //Arrange
            var sut = new EmailValidator();
            //Act
        
            bool isValid = sut.IsEmailValid("name@test");
            //Assert
            Assert.IsTrue(isValid ==false);
            //Assert.IsFalse(isValid);
        }
        public void EmailIsInvalidIf_Null()
        {
            //Arrange
            var sut = new EmailValidator();
            //Act

            bool isValid = sut.IsEmailValid("name@test");
            //Assert
            Assert.IsTrue(isValid == false);

        }
    }
}
