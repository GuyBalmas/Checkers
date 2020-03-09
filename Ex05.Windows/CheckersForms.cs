using System.Windows.Forms;
using CheckersLogic;

namespace WindowsUI
{
    public class CheckersForms 
    {
        public static void SetForms()
        {
            Application.EnableVisualStyles();

            FormGameSetting formGameSetting = new FormGameSetting();
            formGameSetting.ShowDialog();

            if (formGameSetting.DialogResult.Equals(System.Windows.Forms.DialogResult.OK))
            {
                FormGameBoard gameBoard = new FormGameBoard(formGameSetting.GameSettings);
                gameBoard.ShowDialog();

                
                if (!gameBoard.DialogResult.Equals(System.Windows.Forms.DialogResult.OK))
                {
                    Player currentPlayer = gameBoard.Engine.CurrentPlayer;
                    Player waitingPlayer = gameBoard.Engine.WaitingPlayer;
                    if (currentPlayer.HasLessCoins(waitingPlayer))
                    {
                        MessageBox.Show(
                   "You'r coins number is smaller than the rival's!",
                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        gameBoard.ShowDialog();
                    }
                }  
            }
        }
    }
}
