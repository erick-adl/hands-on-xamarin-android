using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Threading.Tasks;

namespace Hello
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        TextView TextView;
        Button bt;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            TextView = FindViewById<TextView>(Resource.Id.retorno);
            bt = FindViewById<Button>(Resource.Id.botao);

            bt.Click += Bt_Click;
        }

        private async void Bt_Click(object sender, System.EventArgs e)
        {
            Android.Util.Log.WriteLine(Android.Util.LogPriority.Info, "test", "Iniciou");
            await Task.Delay(10).ConfigureAwait(false);
            await Pesado().ConfigureAwait(false);

            Android.Util.Log.WriteLine(Android.Util.LogPriority.Info, "test", "Termeinou");
        }

        private async Task Pesado()
        {
            for (int i = 0; i < 1_000; i++)
            {
                await Task.Delay(1000).ConfigureAwait(false);
                RunOnUiThread(() =>
                {
                    TextView.Text = i.ToString();
                });
            }
        }

        protected override void OnRestoreInstanceState(Bundle savedInstanceState)
        {
            base.OnRestoreInstanceState(savedInstanceState);
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
        }


    }
}