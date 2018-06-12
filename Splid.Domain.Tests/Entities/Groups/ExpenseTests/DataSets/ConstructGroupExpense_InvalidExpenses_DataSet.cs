using Splid.Domain.Main.Values;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Splid.Domain.Tests.Entities.Groups.ExpenseTests.DataSets
{
    public class ConstructGroupExpense_InvalidExpenses_DataSet : IEnumerable
    {
        public ConstructGroupExpense_InvalidExpenses_DataSet()
        {

        }

        public IEnumerator GetEnumerator()
        {
            yield return null;
            yield return new List<PersonMoneyOperation>();
            yield return new List<PersonMoneyOperation>();
        }
    }
}
