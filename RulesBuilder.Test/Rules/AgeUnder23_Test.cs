namespace RulesBuilder.Test;

using System;
using RulesBuilder.Rules;
public class AgeUnder23_Test
{
    [Fact]
    public void IsSatisfiedBy_WithNullUser_ThrowsArgumentNullException()
    {
        // Arrange
        Rules.IRule ruleUnderTest = new Rules.AgeUnder23();

        LeaveData leaveData = new LeaveData();

        ruleUnderTest.LeaveData = leaveData;
        ruleUnderTest.BusEntity = null;


        // Act and Assert  
        Assert.Throws<ArgumentNullException>(() => ruleUnderTest.IsSatisfiedBy());
    }

    [Fact]
    public void IsSatisfiedBy_WithNullLeaveData_DoesntThrowExpcetion()
    {
        // Arrange
        Rules.IRule ruleUnderTest = new Rules.AgeUnder23();


        UserDomain user = new UserDomain();
        user.Age = 24;

        ruleUnderTest.LeaveData = null;
        ruleUnderTest.BusEntity = user;

        // Act
        Exception ex = Record.Exception(() => ruleUnderTest.IsSatisfiedBy());

        // Assert
        Assert.IsNotType<ArgumentNullException>(ex);
    }
    [Fact]
    public void IsSatisfiedBy_With16YearOldUser_ThrowsArgumentNullException()
    {
        // Arrange
        Rules.IRule ruleUnderTest = new Rules.AgeUnder23();


        UserDomain user = new UserDomain();
        user.Age = 16;

        ruleUnderTest.LeaveData = null;
        ruleUnderTest.BusEntity = user;

        // Act and Assert
        Assert.Throws<ArgumentNullException>(() => ruleUnderTest.IsSatisfiedBy());
    }
        [Fact]
    public void IsSatisfiedBy_With24YearOldUser_ReturnsTrue()
    {
        // Arrange
        Rules.IRule ruleUnderTest = new Rules.AgeUnder23();

        LeaveData leaveData = new LeaveData();
        UserDomain user= new UserDomain();
        user.Age = 24;

        ruleUnderTest.LeaveData = leaveData;
        ruleUnderTest.BusEntity = user;


        // Act
        bool result = ruleUnderTest.IsSatisfiedBy();
      
        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsSatisfiedBy_With20YearOldUser_RetunsFalse()
    {
        // Arrange
        Rules.IRule ruleUnderTest = new Rules.AgeUnder23();

        LeaveData leaveData = new LeaveData();
        UserDomain user = new UserDomain();
        user.Age = 20;

        ruleUnderTest.LeaveData = leaveData;
        ruleUnderTest.BusEntity = user;


        // Act
        bool result = ruleUnderTest.IsSatisfiedBy();

        // Assert
        Assert.False(result);
    }
}
