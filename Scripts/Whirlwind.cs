using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whirlwind : MonoBehaviour {
    float step = 0;
    float speed = 0.1f;

    private GameObject _player;
    private GameObject _boss;
    [SerializeField]
    private GameObject _curveTransform;

    private Vector3 A;
    private Vector3 B;
    private Vector3 C;

    private void Start() {
        _player = GameObject.FindGameObjectWithTag("Player");
        A = transform.position;
        print("A" + A);
        C = _player.transform.position;
        print("C" + C);
        GetCurve(0.5f);
    }

    private void GetCurve(float amount) {
        _curveTransform = Instantiate(_curveTransform);
        _curveTransform.transform.position = Vector3Utility.GetPos(B, A, amount)/* + GetOffset()*/;
        //_curveTransform.transform.position += GetOffset();
        B = _curveTransform.transform.position;
        print("B" + B);

        GameObject cub = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cub.transform.position = B;
    }

    private void Update() {
        transform.position = Vector3Utility.QuadraticLerp(A, B, C, step += speed * Time.deltaTime);
    }

    private Vector3 GetOffset() {
        Vector3 offset = new Vector3(Random.Range(2, 3), transform.position.y, Random.Range(2, 3));
        bool left = RandomUtility.RandomBool();
        if (left) {
            offset = -offset;
        }

        return offset;
    }

}
