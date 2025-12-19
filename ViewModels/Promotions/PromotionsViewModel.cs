using MVVMGym.Helper;
using MVVMGym.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;


namespace MVVMGym.ViewModels
{
    public class PromotionsViewModel : WszystkieViewModel<Promotions>
    {

        private readonly MVVMGymEntities gymEntities;

        private BaseCommand _LoadCommand;

        private ObservableCollection<Promotions> _promotionsList;
        public ICommand LoadCommand
        {
            get
            {
                if (_LoadCommand == null) { _LoadCommand = new BaseCommand(() => load()); }
                return _LoadCommand;
            }
        }

        public ObservableCollection<Promotions> PromotionsList
        {
            get
            {
                if (_promotionsList == null) load();


                return _promotionsList;
            }

            set
            {
                _promotionsList = value; OnPropertyChanged(() => PromotionsList);
            }
        }


        public PromotionsViewModel() : base()
        {
            base.DisplayName = "Promotions";
        }


        public override void load()
        {
            PromotionsList = new ObservableCollection<Promotions>(
                    base.gymEntities.Promotions.ToList()
               );
        }



    }
}
