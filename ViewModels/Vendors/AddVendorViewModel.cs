using MVVMGym.Models;


namespace MVVMGym.ViewModels
{
    public class AddVendorViewModel : FormViewModel<Vendors>
    {
        public AddVendorViewModel() : base()
        {
            base.DisplayName = "New vendor";
            item = new Vendors();
        }

        public string FirstName
        {
            get
            {
                return item.firstName;
            }
            set
            {
                if (item.firstName != value)
                {
                    item.firstName = value;
                    OnPropertyChanged(() => FirstName);
                }
            }
        }
        public string LastName
        {
            get
            {
                return item.lastName;
            }
            set
            {
                if (item.lastName != value)
                {
                    item.lastName = value;
                    OnPropertyChanged(() => LastName);
                }
            }
        }

        public override void Save()
        {
            gymEntites.Vendors.Add(item);
            gymEntites.SaveChanges();
        }

    }
}
