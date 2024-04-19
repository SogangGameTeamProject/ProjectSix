using UnityEngine;

//���� �Ŵ��� ������ ���� �̱��� Ŭ���� ����
public class Singleton<T> : MonoBehaviour where T : Component
{
    public bool dontDestroy = true;//dontDestroy ����
    private static T _instance;//���� �Ŵ����� �ν��Ͻ�

    //get ������Ƽ�� �ν��Ͻ� ��ȯ
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();
                //������ Ÿ���� ������Ʈ�� ���� �� ���ο� GameObject�� �����ϰ� �̸��� �ٲ� �� �������� ���� ������ ������Ʈ�� �߰�
                if (_instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(T).Name;
                    _instance = obj.AddComponent<T>();
                }
            }
            return _instance;
        }
    }

    public virtual void Awake()
    {
        //������ �ν��Ͻ��� ������ �ν��Ͻ��� �ʱ�ȭ
        if (_instance == null)
        {
            _instance = this as T;
            if(dontDestroy)
                DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }
}