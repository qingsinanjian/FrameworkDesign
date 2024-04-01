using FrameworkDesign;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace CounterApp
{
    public class CounterViewController : MonoBehaviour
    {
        private void Start ()
        {
            CounterModel.Count.OnValueChanged += OnCountChanged;
            OnCountChanged(CounterModel.Count.Value);
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
            transform.Find("CountText").GetComponent<Text>().text = CounterModel.Count.ToString();
        }

        private void OnDestroy()
        {
            CounterModel.Count.OnValueChanged -= OnCountChanged;
        }

    }

    public class CounterModel
    {

        public static BindableProperty<int> Count = new BindableProperty<int>()
        {
            Value = 0
        };
    }
}

