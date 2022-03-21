using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BatEnnemyPatrol : MonoBehaviour
{
    /// Vitesse de l'objet en patrouille
    /// </summary>
    [SerializeField]
    private float _vitesse = 3f;
    /// <summary>
    /// Liste de GO représentant les points à atteindre
    /// </summary>
    [SerializeField]
    private Transform[] _points;

    [SerializeField]
    private float Ondulation = 0f;

    /// <summary>
    /// Référence vers la cible actuelle de l'objet
    /// </summary>
    private Transform _cible = null;
    /// <summary>
    /// Permet de connaître la position actuelle de la cible dans le tableau
    /// </summary>
    private int _indexPoint;
    /// <summary>
    /// Seuil où l'objet change de cible de déplacement
    /// </summary>
    private float _distanceSeuil = 0.3f;
    /// <summary>
    /// Référence vers le sprite Renderer
    /// </summary>
    private SpriteRenderer _sr;
    
   
    // Start is called before the first frame update
    void Start()
    {
        _sr = this.GetComponent<SpriteRenderer>();
        _indexPoint = 0;
        _cible = _points[_indexPoint];
    }

    // Update is called once per frame
    void Update()
    {  
        Vector3 direction = _cible.position - this.transform.position ;

        float x = direction.x;
        float y = (float)Math.Sin(Ondulation * this.gameObject.transform.position.x);
        float z = direction.z;

        Vector3 final = new Vector3(x, y, z);

        this.transform.Translate(final * _vitesse * Time.deltaTime, Space.World);

        if (direction.x < 0 && !_sr.flipX) _sr.flipX = true;
        else if (direction.x > 0 && _sr.flipX) _sr.flipX = false;

        if (Vector3.Distance(this.transform.position, _cible.position) < _distanceSeuil)
        {
            _indexPoint = (++_indexPoint) % _points.Length;
            _cible = _points[_indexPoint];
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        // Ligne entre les cibles
        for (int i = 0; i < _points.Length - 1; i++)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(_points[i].position,
                _points[i + 1].position);
        }

        // Ligne entre l'ennemi et la cible
        if (_cible != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(this.transform.position, _cible.position);
        }
    }
#endif
}
