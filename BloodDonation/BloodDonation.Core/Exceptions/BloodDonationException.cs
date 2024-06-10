using System.Runtime.Serialization;

namespace BloodDonation.Core.Exceptions;

[Serializable]
public class BloodDonationException : SystemException
{
    public BloodDonationException(string messsage) : base(messsage) { }
    protected BloodDonationException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
