using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3Library
{
    public abstract class Subscription
    {
        public double MonthlyFee { get; set; }
        public int MinimumPeriod { get; set; }

        public Subscription(double monthlyFee, int minimumPeriod)
        {
            MonthlyFee = monthlyFee;
            MinimumPeriod = minimumPeriod;
        }

        public abstract List<string> Features();

    }

    public class DomesticSubscription : Subscription
    {
        public DomesticSubscription() : base(5, 1) { }

        public override List<string> Features()
        {
            return new List<string> { "Access to domestic channels", "HD quality streaming" };
        }
    }

    public class EducationalSubscription : Subscription
    {
        public EducationalSubscription() : base(10, 6) { }

        public override List<string> Features()
        {
            return new List<string> { "Access to educational channels", "Offline viewing" };
        }
    }

    public class PremiumSubscription : Subscription
    {
        public PremiumSubscription() : base(30, 3) { }

        public override List<string> Features()
        {
            return new List<string> { "Access to all channels", "4K Ultra HD streaming", "Ad-free viewing", "Offline viewing" };
        }
    }
    // абстрактний метод
    public abstract class SubscriptionFactory
    {
        public abstract Subscription CreateSubscription(int typeOfSubcription);
    }

    public class WebSite : SubscriptionFactory
    {
        public override Subscription CreateSubscription(int typeOfSubcription)
        {
            if(typeOfSubcription == 1)
            {
                return new DomesticSubscription();
            }
            else
            {
                return new PremiumSubscription();
            }
        }
    }

    public class MobileApp : SubscriptionFactory
    {
        public override Subscription CreateSubscription(int typeOfSubcription)
        {
            if (typeOfSubcription == 1)
            {
                return new DomesticSubscription();
            }
            else
            {
                return new PremiumSubscription();
            }
        }
    }

    public class ManagerCall : SubscriptionFactory
    {
        public override Subscription CreateSubscription(int typeOfSubcription)
        {
            if (typeOfSubcription == 1)
            {
                return new DomesticSubscription();
            }
            else if(typeOfSubcription == 2) 
            {
                return new PremiumSubscription();
            }
            else
            {
                return new EducationalSubscription();
            }
        }
    }
}
