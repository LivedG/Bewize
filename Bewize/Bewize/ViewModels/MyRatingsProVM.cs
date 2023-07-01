using System;
using System.Collections.Generic;
using Bewize.HelperResource;
using Bewize.Models;
using Newtonsoft.Json;
using Bewize.Views.MyRating;
using System.Windows.Input;
using Xamarin.Forms.Internals;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Linq;
using System.Diagnostics;

namespace Bewize.ViewModels
{
    public class MyRatingsProVM : BaseViewModel
    {
        private string _message;
        public string message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }

        private int _Questionsectionheight;
        public int Questionsectionheight
        {
            get { return _Questionsectionheight; }
            set
            {
                _Questionsectionheight = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Questionsdetails> _RateQuestionslist;
        public ObservableCollection<Questionsdetails> RateQuestionslist
        {
            get { return _RateQuestionslist; }
            set
            {
                _RateQuestionslist = value;
                OnPropertyChanged(nameof(RateQuestionslist));
            }
        }

        private Questionsdetails _victimcheck;
        public Questionsdetails victimcheck
        {
            get { return _victimcheck; }
            set
            {
                _victimcheck = value;
                OnPropertyChanged();
            }
        }

        private Questionsdetails _userComment;
        public Questionsdetails userComment
        {
            get { return _userComment; }
            set
            {
                _userComment = value;
                OnPropertyChanged();
            }
        }

        private int _Rateone { get; set; }
        public int Rateone
        {
            get { return _Rateone; }
            set
            {
                _Rateone = value;
                OnPropertyChanged();
            }
        }

        private int _Ratetwo { get; set; }
        public int Ratetwo
        {
            get { return _Ratetwo; }
            set
            {
                _Ratetwo = value;
                OnPropertyChanged();
            }
        }

        private int _RateThird { get; set; }
        public int RateThird
        {
            get { return _RateThird; }
            set
            {
                _RateThird = value;
                OnPropertyChanged();
            }
        }

        private int _RateFourth { get; set; }
        public int Ratefourth
        {
            get { return _RateFourth; }
            set
            {
                _RateFourth = value;
                OnPropertyChanged();
            }
        }

        private int _RateFifth { get; set; }
        public int RateFifth
        {
            get { return _RateFifth; }
            set
            {
                _RateFifth = value;
                OnPropertyChanged();
            }
        }

        public Myratingpro_backbtnCommand backbtn_Command { get; set; }

        //public List<Answersdetails> Rates_ansdetails { get; set; }
        //public List<Answersdetails> victim_ansdetails { get; set; }
        //public List<Answersdetails> Commenttxt_ansdetails { get; set; }
        //public List<Questionsdetails> Rate_questionsdetails { get; set; }
        //public List<Questionsdetails> victim_questiondetails { get; set; }
        //public List<Questionsdetails> Commectsection_titledetails { get; set; }

        public SubmitAnsList_reqPara SubmitAnswer_list;


        public MyRatingsProVM()
        {
            backbtn_Command = new Myratingpro_backbtnCommand(this);
            //RateIconClicked = new RatingCommandClicked(this);

            //Rates_ansdetails = new List<Answersdetails>();
            //victim_ansdetails = new List<Answersdetails>();
            //Commenttxt_ansdetails = new List<Answersdetails>();
            //Rate_questionsdetails = new List<Questionsdetails>();
            //victim_questiondetails = new List<Questionsdetails>();
            //Commectsection_titledetails = new List<Questionsdetails>();
        }


        public void RefreshData(int indexer)
        {
            this.RateQuestionslist[indexer] = this.RateQuestionslist[indexer];
        }


        public async void getQuestionslistfromserver()
        {

            try
            {

                string webURL = APIHelper.GetQuestionslist;
                HttpHelper httpHelper = new HttpHelper();
                var Longitude = Preferences.Get("Longitude", "");
                var Latitude = Preferences.Get("Latitude", "");

                var request_para = new getQuestionlist_reqPara();
                request_para.longitude = Longitude;
                request_para.latitude = Latitude;
                //** get  questionlist by location data **** 
                APIResponse res = await httpHelper.callAPI(webURL, JsonConvert.SerializeObject(request_para));
                Debug.WriteLine("----- res ---- " + res);

                if (res.success)
                {
                    List<Questionlistdetails> responselist;
                    Debug.WriteLine("-----" + res.data);
                    var obj = JsonConvert.SerializeObject(res.data);
                    responselist = JsonConvert.DeserializeObject<List<Questionlistdetails>>(obj);
                    var Rate_questionsdetails = responselist.Find(x => x._id == "radio").question;
                    var victim_questiondetails = responselist.Find(x => x._id == "checkbox").question;
                    var Commectsection_titledetails = responselist.Find(x => x._id == "input").question;
                    var Rates_ansdetails = responselist.Find(x => x._id == "radio").anser;
                    var victim_ansdetails = responselist.Find(x => x._id == "checkbox").anser;
                    var Commenttxt_ansdetails = responselist.Find(x => x._id == "input").anser;

                    if (responselist.Find(x => x._id == "radio").question.Count > 0)
                    {
                        RateQuestionslist = new ObservableCollection<Questionsdetails>(Rate_questionsdetails);
                        Questionsectionheight = 150 * this.RateQuestionslist.Count;
                        if (Rates_ansdetails.Count > 0)
                        {
                            for (int I = 0; I < Rates_ansdetails.Count; I++)
                            {
                                for (int j = 0; j < RateQuestionslist.Count; j++)
                                {
                                    if (Rates_ansdetails[I].que == RateQuestionslist[j]._id)
                                    {
                                        if (RateQuestionslist[j].ans == null)
                                        {
                                            RateQuestionslist[j].ans = Rates_ansdetails[I].ans;
                                        }
                                    }

                                    RateQuestionslist[j].ratings.ForEach(x =>
                                    {
                                        x._id = RateQuestionslist[j]._id;
                                    });

                                }
                            }

                            for (int j = 0; j < RateQuestionslist.Count; j++)
                            {
                                for (int i = 0; i < RateQuestionslist[j].ratings.Count; i++)
                                {
                                    if (RateQuestionslist[j].ratings[i]._id == RateQuestionslist[j]._id)
                                    {
                                        RateQuestionslist[j].ratings[i].BGColor = RateQuestionslist[j].ratings[i].currentSelectedAns == RateQuestionslist[j].ans ? MyRatingsProPg.selectedColor : MyRatingsProPg.unSelectedColor;
                                    }
                                }
                            }

                        }

                        // TO add the Ans to submit list 
                        for (int j = 0; j < RateQuestionslist.Count; j++)
                        {
                            var reqPara = new SubmitAns_reqPara();
                            reqPara.ans = RateQuestionslist[j].ans;
                            reqPara.que = RateQuestionslist[j]._id;
                            reqPara.longitude = Longitude;
                            reqPara.latitude = Latitude;
                            reqPara.crime_type = RateQuestionslist[j].crime_type;
                            reqPara.createdby = "";
                            reqPara.updatedby = "";

                            this.SubmitAnswer_list.ansList.Add(reqPara);
                        }
                    }

                    if (victim_questiondetails.Count > 0)
                    {
                        this.victimcheck = victim_questiondetails[0];
                    }
                    if (Commectsection_titledetails.Count > 0)
                    {
                        this.userComment = Commectsection_titledetails[0];
                    }

                    // App.Current.MainPage.Navigation.PopAsync();
                }
                else
                {
                    message = res.message;
                    // isActivity = false;
                    //await App.Current.MainPage.DisplayAlert("", res.message, "OK");
                }
            }
            catch (Exception ex)
            {
                // isActivity = false;
                message = ex.Message.ToString();
                await App.Current.MainPage.DisplayAlert("", ex.Message, "OK");

            }


        }


        public async void SubmitAnswertoServer(SubmitAnsList_reqPara Requestpara)
        {

            try
            {

                string webURL = APIHelper.SubmitAns;
                HttpHelper httpHelper = new HttpHelper();


                APIResponse res = await httpHelper.callAPI(webURL, JsonConvert.SerializeObject(Requestpara.ansList));

                if (res.success)
                {
                    await App.Current.MainPage.DisplayAlert("", res.message, "OK");

                }
                else
                {
                    message = res.message;
                    // isActivity = false;
                    await App.Current.MainPage.DisplayAlert("", res.message, "OK");
                }
                App.Current.MainPage.Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                // isActivity = false;
                message = ex.Message.ToString();
                await App.Current.MainPage.DisplayAlert("", ex.Message, "OK");

            }


        }

        public void MoveBackwardScreen()
        {
            App.Current.MainPage.Navigation.PopAsync();
        }

        public void SelectCrimetypefromPopup()
        {
            App.Current.MainPage.Navigation.PushModalAsync(new CrimeTypePopupPage());
        }

        public ICommand RateIconClicked { private set; get; }

    }



    public class Myratingpro_backbtnCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private MyRatingsProVM VM;

        public Myratingpro_backbtnCommand(MyRatingsProVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.MoveBackwardScreen();
        }
    }


    public class FirstbtnCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private MyRatingsProVM VM;

        public FirstbtnCommand(MyRatingsProVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.MoveBackwardScreen();
        }
    }


    public class SecondbtnCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private MyRatingsProVM VM;

        public SecondbtnCommand(MyRatingsProVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.MoveBackwardScreen();
        }
    }


    public class ThirdbtnCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private MyRatingsProVM VM;

        public ThirdbtnCommand(MyRatingsProVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.MoveBackwardScreen();
        }
    }

    public class FouthbtnCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private MyRatingsProVM VM;

        public FouthbtnCommand(MyRatingsProVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.MoveBackwardScreen();
        }
    }

    public class FifthbtnCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private MyRatingsProVM VM;

        public FifthbtnCommand(MyRatingsProVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.MoveBackwardScreen();
        }
    }
}


