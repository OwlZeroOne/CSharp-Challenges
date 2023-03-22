        /*
        This exercise has you analyze phone numbers.
        You are asked to implement 2 features.
        Phone numbers passed to the routines are guaranteed to be in the form NNN-NNN-NNNN e.g. 212-515-9876 and non-null.
    */
    public static class PhoneNumberAnalysis
    {
        /*
            Your analysis should return 3 pieces of data:

            -   An indication of whether the number has a New York dialing code ie. 212 as the first 3 digits
            -   An indication of whether the number is fake having 555 as a prefix code in positions 5 to 7 (numbering from 1)
            -   The last 4 digits of the number.
            
            Implement the (static) method PhoneNumber.Analyze() to produce the phone number info.
        */
        public static (bool IsNewYork, bool IsFake, string LocalNumber) Analyze(string phoneNumber)
        {
            string firstThree = phoneNumber.Substring(0,3);
            string secondThree = phoneNumber.Substring(4,3);
            string lastFour = phoneNumber.Substring(8,4);

            bool isNewYork = firstThree.Equals("212");
            bool isFake = secondThree.Equals("555");

            return (isNewYork, isFake, lastFour);
        }

        /*
            Implement the (static) method PhoneNumber.IsFake() to detect whether the phone number is fake using the phone number info produced in task 1.
        */
        public static bool IsFake((bool IsNewYork, bool IsFake, string LocalNumber) phoneNumberInfo)
        {
            return phoneNumberInfo.IsFake;
        }
    }