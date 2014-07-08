using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data.Services.Client;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WP8CustomerApp.Common;
using WP8CustomerApp.CustomerOData;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
 
namespace OData.WindowsStore.NetflixDemo.Data
{
    public class SampleDataSource
    {
        private static readonly SampleDataSource Instance = new SampleDataSource();
 
        private static readonly SalesModelContext Context = new SalesModelContext(new Uri("http://localhost:12726/WcfDataService.svc"));
        private readonly ObservableCollection<SampleDataGroup> allGroups = new ObservableCollection<SampleDataGroup>();
 
        static SampleDataSource()
        {
            LoadCustomers();
        }
 
        public ObservableCollection<SampleDataGroup> AllGroups
        {
            get { return allGroups; }
        }
 
        public static IEnumerable<SampleDataItem> Search(string searchString)
        {
            var regex = new Regex(searchString,
                                  RegexOptions.CultureInvariant | RegexOptions.IgnoreCase |
                                  RegexOptions.IgnorePatternWhitespace);
            return
                Instance.AllGroups.SelectMany(g => g.Items).Where(
                    m => regex.IsMatch(m.Title) || regex.IsMatch(m.Subtitle)).Distinct(new SampleDataItemComparer());
        }
 
        public static IEnumerable<SampleDataGroup> GetGroups(string uniqueId)
        {
            if (!uniqueId.Equals("AllGroups"))
                throw new ArgumentException("Only 'AllGroups' is supported as a collection of groups");
 
            return Instance.AllGroups;
        }
 
        public static SampleDataGroup GetGroup(string id)
        {
            IEnumerable<SampleDataGroup> matches =
                Instance.AllGroups.Where(group => group.UniqueId.Equals(id));
            return matches.FirstOrDefault();
        }
 
        public static SampleDataItem GetItem(string id)
        {
            IEnumerable<SampleDataItem> matches =
                Instance.AllGroups.SelectMany(group => group.Items).Where(item => item.UniqueId.Equals(id));
            return matches.FirstOrDefault();
        }
 
        /// <summary>
        /// Loads customers asynchronously onto the singleton.
        /// </summary>
        public static async void LoadCustomers()
        {
            IEnumerable<Customer> customers =
                await ((DataServiceQuery<Customer>)
                        Context.Customers.Expand("Orders/LineItems/Product")).ExecuteAsync();
                 
 
            foreach (var cust in customers)
            {

              SampleDataGroup custGroup = GetGroup(cust.CustomerId.ToString());
              if (custGroup == null)
              {
                custGroup = new SampleDataGroup(cust.CustomerId.ToString(),
                                                cust.FirstName.Trim() + " " + cust.LastName.Trim(),
                                                String.Empty, String.Empty, String.Empty);
                Instance.AllGroups.Add(custGroup);
              }
              var content = new StringBuilder();
                    // Write additional things to content here if you want them to display in the item detail.
                custGroup.Items.Add(
                  new SampleDataItem(
                    cust.CustomerId.ToString(),
                    cust.LastName,
                    cust.FirstName,
                    string.Empty,
                    "Order Count:" + cust.Orders.Count.ToString(),
                    content.ToString()));  

              }
              //foreach (var order in cust.Orders)
              //{
              //  SampleDataGroup orderGroup = GetGroup(order.OrderId.ToString());

              //  if (orderGroup == null)
              //  {
              //    orderGroup = new SampleDataGroup(order.OrderDate.Date.ToString(),
              //      order.OrderDate.Date.ToString(), String.Empty,
              //                                String.Empty,
              //                                String.Empty);
              //    Instance.AllGroups.Add(orderGroup);
              //  }
              //  var content = new StringBuilder();
              //    // Write additional things to content here if you want them to display in the item detail.
              //  orderGroup.Items.Add(new SampleDataItem(order.OrderId.ToString(), order.OrderDate.ToString(),
              //      "","","Order placed on " + order.OrderDate.Date.ToString(),"some stuff"));}


            }
        }
    }
 
    [WebHostHidden]
    public abstract class ODataBindable : BindableBase
    {
        private static readonly Uri BaseUri = new Uri("ms-appx:///");
        private string description = string.Empty;
        private ImageSource image;
        private String imagePath;
        private string subtitle = string.Empty;
        private string title = string.Empty;
 
        private string uniqueId = string.Empty;
 
        protected ODataBindable(String uniqueId, String title, String subtitle, String imagePath, String description)
        {
            this.uniqueId = uniqueId;
            this.title = title;
            this.subtitle = subtitle;
            this.description = description;
            this.imagePath = imagePath;
        }
 
        public string UniqueId
        {
            get { return uniqueId; }
            set { SetProperty(ref uniqueId, value); }
        }
 
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
 
        public string Subtitle
        {
            get { return subtitle; }
            set { SetProperty(ref subtitle, value); }
        }
 
        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }
 
        public ImageSource Image
        {
            get
            {
                if (image == null && imagePath != null)
                {
                    image = new BitmapImage(new Uri(BaseUri, imagePath));
                }
                return image;
            }
 
            set
            {
                imagePath = null;
                SetProperty(ref image, value);
            }
        }
 
        public void SetImage(String path)
        {
            image = null;
            imagePath = path;
            OnPropertyChanged("Image");
        }
 
        public override string ToString()
        {
            return Title;
        }
    }
 
    /// <summary>
    /// Functionally represents a genre in the Netflix catalog. Name and functionality
    /// left as-is to minimize changes to XAML bindings.
    /// </summary>
    public class SampleDataGroup : ODataBindable
    {
        private readonly ObservableCollection<SampleDataItem> items = new ObservableCollection<SampleDataItem>();
 
        private readonly ObservableCollection<SampleDataItem> topItem = new ObservableCollection<SampleDataItem>();
 
        public SampleDataGroup(String uniqueId, String title, String subtitle, String imagePath, String description)
            : base(uniqueId, title, subtitle, imagePath, description)
        {
            Items.CollectionChanged += ItemsCollectionChanged;
        }
 
        public ObservableCollection<SampleDataItem> Items
        {
            get { return items; }
        }
 
        public ObservableCollection<SampleDataItem> TopItems
        {
            get { return topItem; }
        }
 
        private void ItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // Provides a subset of the full items collection to bind to from a GroupedItemsPage
            // for two reasons: GridView will not virtualize large items collections, and it
            // improves the user experience when browsing through groups with large numbers of
            // items.
            //
            // A maximum of 12 items are displayed because it results in filled grid columns
            // whether there are 1, 2, 3, 4, or 6 rows displayed
 
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (SampleDataItem movie in e.NewItems)
                    {
                        movie.Group = this;
                    }
                    if (e.NewStartingIndex < 12)
                    {
                        TopItems.Insert(e.NewStartingIndex, Items[e.NewStartingIndex]);
                        if (TopItems.Count > 12)
                        {
                            TopItems.RemoveAt(12);
                        }
                    }
                    break;
                case NotifyCollectionChangedAction.Move:
                    if (e.OldStartingIndex < 12 && e.NewStartingIndex < 12)
                    {
                        TopItems.Move(e.OldStartingIndex, e.NewStartingIndex);
                    }
                    else if (e.OldStartingIndex < 12)
                    {
                        TopItems.RemoveAt(e.OldStartingIndex);
                        TopItems.Add(Items[11]);
                    }
                    else if (e.NewStartingIndex < 12)
                    {
                        TopItems.Insert(e.NewStartingIndex, Items[e.NewStartingIndex]);
                        TopItems.RemoveAt(12);
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    if (e.OldStartingIndex < 12)
                    {
                        TopItems.RemoveAt(e.OldStartingIndex);
                        if (Items.Count >= 12)
                        {
                            TopItems.Add(Items[11]);
                        }
                    }
                    break;
                case NotifyCollectionChangedAction.Replace:
                    if (e.OldStartingIndex < 12)
                    {
                        TopItems[e.OldStartingIndex] = Items[e.OldStartingIndex];
                    }
                    break;
                case NotifyCollectionChangedAction.Reset:
                    TopItems.Clear();
                    while (TopItems.Count < Items.Count && TopItems.Count < 12)
                    {
                        TopItems.Add(Items[TopItems.Count]);
                    }
                    break;
            }
        }
    }
 
    /// <summary>
    /// Functionally represents a movie in the Netflix catalog. Name and functionality
    /// left as-is to minimize changes to XAML bindings.
    /// </summary>
    public class SampleDataItem : ODataBindable
    {
        private string content = string.Empty;
 
        private SampleDataGroup group;
 
        public SampleDataItem(String uniqueId, String title, String subtitle, String imagePath, String description,
                              String content)
            : base(uniqueId, title, subtitle, imagePath, description)
        {
            this.content = content;
        }
 
        public string Content
        {
            get { return content; }
            set { SetProperty(ref content, value); }
        }
 
        public SampleDataGroup Group
        {
            get { return group; }
            set { SetProperty(ref group, value); }
        }
    }
 
    /// <summary>
    /// Allows us to get a distinct set of search results.
    /// </summary>
    public class SampleDataItemComparer : IEqualityComparer<SampleDataItem>
    {
        #region IEqualityComparer<SampleDataItem> Members
 
        public bool Equals(SampleDataItem x, SampleDataItem y)
        {
            return String.Equals(x.UniqueId, y.UniqueId, StringComparison.Ordinal);
        }
 
        public int GetHashCode(SampleDataItem obj)
        {
            return obj.UniqueId.GetHashCode();
        }
 
        #endregion
    }
 
    public static class ExtensionMethods
    {
        public static async Task<IEnumerable<T>> ExecuteAsync<T>(this DataServiceQuery<T> query)
        {
            return await Task.Factory.FromAsync<IEnumerable<T>>(query.BeginExecute(null, null), query.EndExecute);
        }
 
        public static async Task<IEnumerable<TResult>> ExecuteAsync<TResult>(this DataServiceContext context,
                                                                             Uri requestUri)
        {
            return await Task.Factory.FromAsync<IEnumerable<TResult>>(context.BeginExecute<TResult>(requestUri, null, null), 
                                                             executeAsyncResult =>
                                                                 {
                                                                     List<TResult> executeResult =
                                                                         context.EndExecute<TResult>(executeAsyncResult)
                                                                             .ToList();
                                                                     return executeResult;
                                                                 });
        }
    }

