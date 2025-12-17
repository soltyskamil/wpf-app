using MVVMGym.Helper;
using MVVMGym.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMGym.ViewModels
{
    public class MembershipPlansViewModel : WszystkieViewModel<MembershipPlans>
    {
        private readonly GymEntities gymEntities;

        private BaseCommand _LoadCommand;

        private ObservableCollection<MembershipPlans> _membershipList;
        public ICommand LoadCommand
        {
            get
            {
                if (_LoadCommand == null) { _LoadCommand = new BaseCommand(() => load()); }
                return _LoadCommand;
            }
        }

        public ObservableCollection<MembershipPlans> MembershipList
        {
            get
            {
                if (_membershipList == null) load();


                return _membershipList;
            }

            set
            {
                _membershipList = value; OnPropertyChanged(() => MembershipList);
            }
        }


        public MembershipPlansViewModel() : base()
        {
            base.DisplayName = "Wszystkie plany";
        }


        public override void load()
        {
            MembershipList = new ObservableCollection<MembershipPlans>(
                    base.gymEntities.MembershipPlans.ToList()
               );
        }



    }
}
