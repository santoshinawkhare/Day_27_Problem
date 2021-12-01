using System;
using System.Collections.Generic;
using System.Text;

namespace Day_27_Problem
{
   public class AddressBookComparer : Comparer<ContactPerson>
    {
        public enum SortByField
        {
            FirstNmae,
            State,
            City,
            Zip
        }

        public SortByField compareByField;

        public AddressBookComparer(SortByField sortByField)
        {
            this.compareByField = sortByField;
        }

        public override int Compare(ContactPerson x, ContactPerson y)
        {
            switch (compareByField)
            {
                case SortByField.FirstNmae:
                    return x.FirstName.CompareTo(y.FirstName);

                case SortByField.State:
                    return x.State.CompareTo(y.State);

                case SortByField.City:
                    return x.City.CompareTo(y.City);

                case SortByField.Zip:
                    return x.Zip.CompareTo(y.Zip);

            }
            return x.FirstName.CompareTo(y.FirstName);
        }

    }
}
