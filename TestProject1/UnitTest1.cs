using System.ComponentModel.DataAnnotations;
using Bunit;
using PhoneCase.Pages;

namespace TestProject1
{
    public class UnitTest1 : TestContext
    {
        [Fact]
        public void PhoneCaseBrandIsRequired()
        {
            var component = RenderComponent<CaseForm>();
            component.Find("button[type='submit']").Click();
            var validationMessage = component.Find(".validation-message");
            Assert.Contains("Brand is required", validationMessage.TextContent);
        }

        [Fact]
        public void PhoneCaseBrandShouldNotExceed25Characters()
        {
            var component = RenderComponent<CaseForm>();
            component.Find("#brand").Change(new string('A', 26));
            component.Find("button[type='submit']").Click();
            var validationMessages = component.FindAll(".validation-message");
            Assert.Contains(validationMessages, vm => vm.TextContent.Contains("Brand should not exceed 25 characters"));
        }

        [Fact]
        public void ModelIsRequired()
        {
            var component = RenderComponent<CaseForm>();
            component.Find("button[type='submit']").Click();
            var validationMessages = component.FindAll(".validation-message");
            Assert.Contains(validationMessages, vm => vm.TextContent.Contains("Model is required"));
        }

        [Fact]
        public void ModelShouldNotExceed25Characters()
        {
            var component = RenderComponent<CaseForm>();
            component.Find("#model").Change(new string('B', 26));
            component.Find("button[type='submit']").Click();
            var validationMessages = component.FindAll(".validation-message");
            Assert.Contains(validationMessages, vm => vm.TextContent.Contains("Model should not exceed 25 characters"));
        }

        [Fact]
        public void MaterialIsRequired()
        {
            var component = RenderComponent<CaseForm>();
            component.Find("button[type='submit']").Click();
            var validationMessages = component.FindAll(".validation-message");
            Assert.Contains(validationMessages, vm => vm.TextContent.Contains("Material is required"));
        }

        [Fact]
        public void MaterialCannotExceed30Characters()
        {
            var component = RenderComponent<CaseForm>();
            component.Find("#material").Change(new string('C', 31));
            component.Find("button[type='submit']").Click();
            var validationMessages = component.FindAll(".validation-message");
            Assert.Contains(validationMessages, vm => vm.TextContent.Contains("Material cannot exceed 30 characters"));
        }

        [Fact]
        public void PriceIsRequired()
        {
            var component = RenderComponent<CaseForm>();
            component.Find("button[type='submit']").Click();
            var validationMessages = component.FindAll(".validation-message");
            Assert.Contains(validationMessages, vm => vm.TextContent.Contains("Price is required"));
        }

        [Fact]
        public void PriceWithinValidRange()
        {
            var component = RenderComponent<CaseForm>();
            component.Find("#cost").Change("0");
            component.Find("button[type='submit']").Click();
            var validationMessages = component.FindAll(".validation-message");
            Assert.Contains(validationMessages, vm => vm.TextContent.Contains("Price must be between 1 and 500"));

            component.Find("#cost").Change("501");
            component.Find("button[type='submit']").Click();
            validationMessages = component.FindAll(".validation-message");
            Assert.Contains(validationMessages, vm => vm.TextContent.Contains("Price must be between 1 and 500"));
        }

        [Fact]
        public void TrimColorIsRequired()
        {
            var component = RenderComponent<CaseForm>();
            component.Find("button[type='submit']").Click();
            var validationMessages = component.FindAll(".validation-message");
            Assert.Contains(validationMessages, vm => vm.TextContent.Contains("Trim color is required"));
        }

        [Fact]
        public void TrimColorShouldNotExceed30Characters()
        {
            var component = RenderComponent<CaseForm>();
            component.Find("#trimColor").Change(new string('D', 31));
            component.Find("button[type='submit']").Click();
            var validationMessages = component.FindAll(".validation-message");
            Assert.Contains(validationMessages, vm => vm.TextContent.Contains("Trim color should not exceed 30 characters"));
        }

        [Fact]
        public void AccentColorIsRequired()
        {
            var component = RenderComponent<CaseForm>();
            component.Find("button[type='submit']").Click();
            var validationMessages = component.FindAll(".validation-message");
            Assert.Contains(validationMessages, vm => vm.TextContent.Contains("Accent color is required"));
        }

        [Fact]
        public void AccentColorShouldNotExceed30Characters()
        {
            var component = RenderComponent<CaseForm>();
            component.Find("#accentColor").Change(new string('E', 31));
            component.Find("button[type='submit']").Click();
            var validationMessages = component.FindAll(".validation-message");
            Assert.Contains(validationMessages, vm => vm.TextContent.Contains("Accent color should not exceed 30 characters"));
        }
    }
}
