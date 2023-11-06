namespace RulesBuilder.Test;

using System;
using RulesBuilder.Rules;
using RulesBuilder.Policys;

public class PolicyExample_Test{
    [Fact]
    public void CheckPolicy_With18YearOldUser_ReturnsFalse()
    {
        // Arrange
        IList<string> outErrors = new List<string>();

        ILeaveData Leave = new LeaveData();
        Leave.StartDate = new DateTime(2023, 10, 10);
        Leave.EndDate = new DateTime(2023, 10, 11);
        Leave.Reason = "Maternity";

        IUserDomain User = new UserDomain();
        User.Age = 18;
        User.Genre = "F";

        PolicyExample policyExample = new PolicyExample();
        policyExample.LeaveData = Leave;
        policyExample.UserDomain = User;


        //Act
        bool result = policyExample.CheckPolicy(out outErrors);

        //Assert
        Assert.False(result);
    }

    [Fact]
    public void CheckPolicy_With18YearOldUser_ReturnRightErrorMessage()
    {
        // Arrange
        IList<string> outErrors = new List<string>();

        ILeaveData Leave = new LeaveData();
        Leave.StartDate = new DateTime(2023, 10, 10);
        Leave.EndDate = new DateTime(2023, 10, 15);
        Leave.Reason = "Maternity";

        IUserDomain User = new UserDomain();
        User.Age = 18;
        User.Genre = "F";

        PolicyExample policyExample = new PolicyExample();
        policyExample.LeaveData = Leave;
        policyExample.UserDomain = User;


        //Act
        bool result = policyExample.CheckPolicy(out outErrors);

        //Assert
        Assert.Contains(new Rules.AgeUnder23().ErrorMessage, outErrors);


    }

    [Fact]
    public void CheckPolicy_WithMaleForMaternity_ReturnsFalse()
    {
        // Arrange
        IList<string> outErrors = new List<string>();

        ILeaveData Leave = new LeaveData();
        Leave.StartDate = new DateTime(2023, 10, 10);
        Leave.EndDate = new DateTime(2023, 10, 12);
        Leave.Reason = "Maternity";

        IUserDomain User = new UserDomain();
        User.Age = 25;
        User.Genre = "M";

        PolicyExample policyExample = new PolicyExample();
        policyExample.LeaveData = Leave;
        policyExample.UserDomain = User;


        //Act
        bool result = policyExample.CheckPolicy(out outErrors);

        //Assert
        Assert.False(result);
    }

    [Fact]
    public void CheckPolicy_WithWomanForMaternity_ReturnsTrue()
    {
        // Arrange
        IList<string> outErrors = new List<string>();

        ILeaveData Leave = new LeaveData();
        Leave.StartDate = new DateTime(2023, 10, 10);
        Leave.EndDate = new DateTime(2023, 10, 12);
        Leave.Reason = "Maternity";

        IUserDomain User = new UserDomain();
        User.Age = 25;
        User.Genre = "F";

        PolicyExample policyExample = new PolicyExample();
        policyExample.LeaveData = Leave;
        policyExample.UserDomain = User;


        //Act
        bool result = policyExample.CheckPolicy(out outErrors);

        //Assert
        Assert.True(result);
    }

    [Fact]
    public void CheckPolicy_WithMaleForMaternety_ReturnsRigthErrorMessage()
        {
            // Arrange
            IList<string> outErrors = new List<string>();

            ILeaveData Leave = new LeaveData();
            Leave.StartDate = new DateTime(2023, 10, 10);
            Leave.EndDate = new DateTime(2023, 10, 15);
            Leave.Reason = "Maternity";

            IUserDomain User = new UserDomain();
            User.Age = 21;
            User.Genre = "M";

            PolicyExample policyExample = new PolicyExample();
            policyExample.LeaveData = Leave;
            policyExample.UserDomain = User;


            //Act
            bool result = policyExample.CheckPolicy(out outErrors);

        //Assert
        Assert.Contains(new Rules.OnlyWomenTakeMaternityLeaves().ErrorMessage, outErrors);
       

    }

    [Fact]
    public void CheckPolicy_With2DayLeave_ReturnsTrue()
    {
        // Arrange
        IList<string> outErrors = new List<string>();

        ILeaveData Leave = new LeaveData();
        Leave.StartDate = new DateTime(2023, 10, 10);
        Leave.EndDate = new DateTime(2023, 10, 11);
        Leave.Reason = "Maternity";

        IUserDomain User = new UserDomain();
        User.Age = 25;
        User.Genre = "F";

        PolicyExample policyExample = new PolicyExample();
        policyExample.LeaveData = Leave;
        policyExample.UserDomain = User;


        //Act
        bool result = policyExample.CheckPolicy(out outErrors);

        //Assert
        Assert.True(result);
    }

    [Fact]
    public void CheckPolicy_With5DayLeave_ReturnsRightErrorMessage()
    {
        // Arrange
        IList<string> outErrors = new List<string>();

        ILeaveData Leave = new LeaveData();
        Leave.StartDate = new DateTime(2023, 10, 10);
        Leave.EndDate = new DateTime(2023, 10, 15);
        Leave.Reason = "Maternity";

        IUserDomain User = new UserDomain();
        User.Age = 21;
        User.Genre = "M";

        PolicyExample policyExample = new PolicyExample();
        policyExample.LeaveData = Leave;
        policyExample.UserDomain = User;


        //Act
        bool result = policyExample.CheckPolicy(out outErrors);

        //Assert
        Assert.Contains(new Rules.NoMoreThanXConsecutiveDays().ErrorMessage, outErrors);


    }


    [Fact]
    public void CheckPolicy_WithNullUser_ThrowsArgumentNullException()
    {  // Arrange
        IList<string> outErrors = new List<string>();

        ILeaveData Leave = new LeaveData();
        Leave.StartDate = new DateTime(2023, 10, 10);
        Leave.EndDate = new DateTime(2023, 10, 15);
        Leave.Reason = "Maternity";

        PolicyExample policyExample = new PolicyExample();
        policyExample.LeaveData = Leave;
        policyExample.UserDomain = null;


        //Act and Assert
        Assert.Throws<ArgumentNullException>(() => policyExample.CheckPolicy(out outErrors));
    }

    [Fact]
    public void CheckPolicy_WithNullLeaveData_ThrowsArgumentNullException()
    {  // Arrange
       // Arrange
        IList<string> outErrors = new List<string>();

      
        IUserDomain User = new UserDomain();
        User.Age = 21;
        User.Genre = "M";

        PolicyExample policyExample = new PolicyExample();
        policyExample.LeaveData = null;
        policyExample.UserDomain = User;



        //Act and Assert
        Assert.Throws<ArgumentNullException>(() => policyExample.CheckPolicy(out outErrors));
    }



}
