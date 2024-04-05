using FrameworkDesign;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Counter
{
    public class CounterViewController : MonoBehaviour
    {
        private ICounterModel mCounterModel;
        private void Start ()
        {
            mCounterModel = CounterApp.Get<ICounterModel>();
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

    public interface ICounterModel : IModel
    {
        BindableProperty<int> Count { get; }
    }

    public class CounterModel : ICounterModel
    {
        public void Init()
        {
            var storage = Architecture.GetUtility<IStorage>();
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
        public IArchitecture Architecture { get; set; }
    }
}

