using MVVMGym.Models;


namespace MVVMGym.ViewModels
{
    public class AddVendorViewModel : FormViewModel<Vendors>
    {
        public AddVendorViewModel() : base()
        {
            base.DisplayName = "Add vendor";
            item = new Vendors();
        }

        public string FirstName
        {
            get
            {
                return item.first_name;
            }
            set
            {
                if (item.first_name != value)
                {
                    item.first_name = value;
                    OnPropertyChanged(() => FirstName);
                }
            }
        }
        public string LastName
        {
            get
            {
                return item.last_name;
            }
            set
            {
                if (item.last_name != value)
                {
                    item.last_name = value;
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
