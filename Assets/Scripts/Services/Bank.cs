using TMPro;
using UnityEngine;

public class Bank : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI balanceText;
    [SerializeField] int startingBalance = 100;

    int currentBalance;
    public int CurrentBalance {  get { return currentBalance; } }

    void Start()
    {
        currentBalance = startingBalance;
        UpdateBalanceText();
    }
    
    public void MoneyDeposit( int amount)
    {
        currentBalance += amount;
        UpdateBalanceText();
    }

    public void MoneyWithdrawal( int amount )
    {
        currentBalance -= amount;
        UpdateBalanceText();
    }

    private void UpdateBalanceText()
    {
        balanceText.text = "Balance: $" + currentBalance.ToString();
    }
}
