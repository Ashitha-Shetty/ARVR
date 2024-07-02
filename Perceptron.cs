using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class TrainingSet
{
    public double[] input;
    public double output;
}
public class Perceptron : MonoBehaviour
{
    List<TrainingSet> ts = new List<TrainingSet>();
    double[] weights = { 0, 0 };
    double bias = 0;
    double totalError = 0;

    //public GameObject npc;
    public Rigidbody rb;
    public Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        InitialiseWeights();
    }
    public void SendInput(double i1, double i2, double o)
    {
        //react
        double result = CalcOutput(i1, i2);
        Debug.Log(result);
        if (result == 0)
        {
            anim.SetTrigger("Crouch");
            rb.isKinematic = false;
        }
        else
        {
            rb.isKinematic = true;
        }
        //learn from it for next time
        TrainingSet s = new TrainingSet();
        s.input = new double[2] { i1, i2 };
        s.output = o;
        ts.Add(s);
        Train();
    }
    double DotProductBias(double[] w1, double[] v2)
    {
        if (w1 == null || v2 == null)
            return -1;
        if (w1.Length != v2.Length)
            return -1;
        double y = 0;
        for (int x = 0; x < w1.Length; x++)
        {
            y += w1[x] * v2[x];
        }
        y += bias;

        return y;
    }
    double CalcOutput(int i)
    {
        return (ActivationFunction(DotProductBias(weights, ts[i].input)));
    }
    double CalcOutput(double i1, double i2)
    {
        double[] inp = new double[] { i1, i2 };
        return (ActivationFunction(DotProductBias(weights, inp)));
    }
    double ActivationFunction(double y)
    {
        if (y > 0) return (1);
        return (0);
    }
    void InitialiseWeights()
    {
        for (int i = 0; i < weights.Length; i++)
        {
            weights[i] = Random.Range(-1.0f, 1.0f);
        }
        bias = Random.Range(-1.0f, 1.0f);
    }
    void UpdateWeights(int j)
    {
        double error = ts[j].output - CalcOutput(j);
        totalError += Mathf.Abs((float)error);
        for (int i = 0; i < weights.Length; i++)
        {
            weights[i] = weights[i] + error * ts[j].input[i];
        }
        bias += error;
    }
    void Train()
    {
        for (int t = 0; t < ts.Count; t++)
        {
            UpdateWeights(t);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            InitialiseWeights();
            ts.Clear();
        }
    }
}