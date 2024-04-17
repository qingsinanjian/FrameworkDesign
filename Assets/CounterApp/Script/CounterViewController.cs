using FrameworkDesign;
using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

namespace Counter
{
    public class CounterViewController : MonoBehaviour, IController
    {
        private ICounterModel mCounterModel;

        private void Start ()
        {
            mCounterModel = this.GetModel<ICounterModel>();
            mCounterModel.Count.OnValueChanged += OnCountChanged;
            OnCountChanged(mCounterModel.Count.Value);
            //UpdateView();
            transform.Find("BtnAdd").GetComponent<Button>().onClick.AddListener(() =>
            {
                //CounterModel.Count.Value++;
                //UpdateView();
                this.SendCommand<AddCountCommand>();
            });

            transform.Find("BtnSub").GetComponent<Button>().onClick.AddListener(() =>
            {
                //CounterModel.Count.Value--;
                //UpdateView();
                this.SendCommand<SubCountCommand>();
            });
        }

        private void OnCountChanged(int newCount)
        {
            transform.Find("CountText").GetComponent<Text>().text = newCount.ToString();
        }

        private void UpdateView()
        {
            transform.Find("CountText").GetComponent<Text>().text = mCounterModel.Count.ToString();
        }

        private void OnDestroy()
        {
            mCounterModel.Count.OnValueChanged -= OnCountChanged;
        }

        IArchitecture IBelongToArchitecture.GetArchitecture()
        {
            return CounterApp.Interface;
        }
    }

    public interface ICounterModel : IModel
    {
        BindableProperty<int> Count { get; }
    }

    public class CounterModel : AbstractModel, ICounterModel
    {
        public override void OnInit()
        {
            var storage = this.GetUtility<IStorage>();
            Count.Value = storage.LoadInt("COUNTER_COUNT", 0);
            Count.OnValueChanged += (count) =>
            {
                storage.SaveInt("COUNTER_COUNT", count);
            };
        }

        public BindableProperty<int> Count { get; } = new BindableProperty<int>()
        {
            Value = 0
        };
    }
}

