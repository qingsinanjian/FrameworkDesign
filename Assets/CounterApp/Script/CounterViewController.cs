using FrameworkDesign;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace CounterApp
{
    public class CounterViewController : MonoBehaviour
    {
        private CounterModel mCounterModel;
        private void Start ()
        {
            mCounterModel = CounterApp.Get<CounterModel>();
            mCounterModel.Count.OnValueChanged += OnCountChanged;
            OnCountChanged(mCounterModel.Count.Value);
            //UpdateView();
            transform.Find("BtnAdd").GetComponent<Button>().onClick.AddListener(() =>
            {
                //CounterModel.Count.Value++;
                //UpdateView();
                new AddCountCommand().Execute();
            });

            transform.Find("BtnSub").GetComponent<Button>().onClick.AddListener(() =>
            {
                //CounterModel.Count.Value--;
                //UpdateView();
                new SubCountCommand().Execute();
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

    }

    public class CounterModel
    {
        //private CounterModel() { }

        public BindableProperty<int> Count = new BindableProperty<int>()
        {
            Value = 0
        };
    }
}

