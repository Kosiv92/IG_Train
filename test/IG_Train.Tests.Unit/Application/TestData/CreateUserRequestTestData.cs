using System.Collections;


namespace IG_Train.Tests.Unit.Application.TestData
{
    public class CreateUserRequestTestData : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator()
        {
            //correct input data
            yield return new object?[] { "User", "usermail@mail.com", "Qhxov123!", true };
            yield return new object?[] { "User", "usermail@mail.com", "qhxoV13#", true };
            //incorrect username
            yield return new object?[] { null, "usermail@mail.com", "Pvskr123~", false };
            yield return new object?[] { "", "usermail@mail.com", "cJebp123#", false };
            //incorrect email
            yield return new object?[] { "User", null, "Ycpwm123!", false };
            yield return new object?[] { "User", "", "poJsr123!", false };
            yield return new object?[] { "User", "email", "zomFw123!", false };
            yield return new object?[] { "User", "email@", "evplA123!", false };
            //incorrect password
            yield return new object?[] { "User", "usermail@mail.com", null, false };
            yield return new object?[] { "User", "usermail@mail.com", "", false };
            yield return new object?[] { "User", "usermail@mail.com", "4R&l", false };
            yield return new object?[] { "User", "usermail@mail.com", "bjspc123!", false };
            yield return new object?[] { "User", "usermail@mail.com", "EMAPV123!", false };
            yield return new object?[] { "User", "usermail@mail.com", "WjVsptnf!", false };
            yield return new object?[] { "User", "usermail@mail.com", "WjV1pt2fT", false };
            yield return new object?[] { "User", "usermail@mail.com", "3719123!", false };
            yield return new object?[] { "User", "usermail@mail.com", "37a91Y3t", false };
            yield return new object?[] { "User", "usermail@mail.com", "!@&^#%(@", false };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}