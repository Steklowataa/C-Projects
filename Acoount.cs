// using System;
// using Microsoft.VisualBasic;

// namespace Bank {
//     public class Account : IAccount
//     {
//         public Account(string name, decimal balance = 0) {
//             if(name == null) throw new ArgumentOutOfRangeException("Name is null");
//             if(name.Length < 0) throw new ArgumentException("Name is to short");

//             name = name.Trim();
//             if(name.Length < 3) throw new ArgumentException("Name is to short");
//             Name = name;
//             if(balance < 0) throw new ArgumentOutOfRangeException("Ujemne saldo");
//             Balance = balance;

//             IsBlocked =false;
//         }
//         public string Name {get; }

//     private decimal _balance;
//         public decimal Balance {
//             get => _balance;
//             //private set => _balance = (value >= 0) ? Math.Round(value, 4) : throw new ArgumentOutOfRangeException("Ujemne saldo");
//             private set {
//                 if(value < 0) {
//                     throw new ArgumentOutOfRangeException("Ujemne saldo"); 
//                 }
//                 else{
//                     _balance = Math.Round(value, 4);
//                 }
//             }
//         }

//         public bool IsBlocked {get; private set; }

//         public void Block() => IsBlocked = true;
//         public void Unblock() => IsBlocked = false;

//         public bool Deposit(decimal amount)
//         {
//             if(amount < 0 || IsBlocked) {
//                 return false;
//             }
//             Balance += amount;
//             // if(Balance == 0) {
//             //     return false;
//             // }
//             //if(Balance < 0) throw new ArgumentOutOfRangeException("False");
//             return true;
//         }
//         public bool Withdrawal(decimal amount)
//         {
//             if( IsBlocked || amount < 0 || amount > Balance) {
//                 return false;
//             }
//             Balance -= amount;
//             return true;
//         }
//         public override string ToString() {
//             if(IsBlocked == false) {
//                 return $"Account name: {Name}, balance: {Balance:F2}";
//             } else{
//                 return $"Account name: {Name}, balance: {Balance:F2}, blocked";
//     }
//         }
//     }
// }
using System;

namespace Bank
{
    public class Account : IAccount
    {
         public Account(string name, decimal balance = 0) {
            if(name == null) throw new ArgumentOutOfRangeException("Name is null");
            if(name.Length < 0) throw new ArgumentException("Name is to short");

            name = name.Trim();
            if(name.Length < 3) throw new ArgumentException("Name is to short");
            Name = name;
            if(balance < 0) throw new ArgumentOutOfRangeException("Ujemne saldo");
            Balance = balance;

            IsBlocked =false;
        }

        public string Name { get; }

        private decimal _balance;

        public decimal Balance
        {
            get => _balance;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Negative balance");
                }
                _balance = Math.Round(value, 4);
            }
        }

        public bool IsBlocked { get; private set; }

        public void Block() => IsBlocked = true;
        public void Unblock() => IsBlocked = false;

        public bool Deposit(decimal amount)
        {
            if (amount < 0 || IsBlocked)
            {
                return false;
            }

            Balance += amount;
            return true;
        }   
        public bool Withdrawal(decimal amount)
        {
            if(IsBlocked || amount <= 0 || amount > Balance) {
                return false;
            }
            Balance -= amount;
            return true;
}

        public override string ToString() => IsBlocked
            ? $"Account name: {Name}, balance: {Balance:F2}, blocked"
            : $"Account name: {Name}, balance: {Balance:F2}";
    }
}
