using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SwipeInput : MonoBehaviour, IDragHandler, IEndDragHandler{
    private Vector3 panelLocation;
    public float percentThreshold = 0.2f;
    public float easing = 0.5f;
    private int totalPages = 1;
    private int currentPage = 1;
	private float prevPage;
	public Transform[] pages;
	public RectTransform[] titik;

	public Transform choosenOne;


    void Start(){
        panelLocation = transform.position;
		totalPages = pages.Length;
		choosenOne.position = new Vector3(titik[0].position.x, choosenOne.position.y, choosenOne.position.z);
		float pageCount = 0f;
		foreach (Transform page in pages)
		{
			page.position = new Vector3(((Screen.width/2) + (Screen.width*pageCount)), page.position.y, page.position.z);
			pageCount += 1f;
		}
    }
    public void OnDrag(PointerEventData data){
        float difference = data.pressPosition.x - data.position.x;
        transform.position = panelLocation - new Vector3(difference, 0, 0);
    }
    public void OnEndDrag(PointerEventData data){
        float percentage = (data.pressPosition.x - data.position.x) / Screen.width;
        if(Mathf.Abs(percentage) >= percentThreshold){
            Vector3 newLocation = panelLocation;
            if(percentage > 0 && currentPage < totalPages){
				prevPage = titik[currentPage - 1].position.x;
                currentPage++;
				
                newLocation += new Vector3(-Screen.width, 0, 0);
            }else if(percentage < 0 && currentPage > 1){
				prevPage = currentPage;
                currentPage--;
                newLocation += new Vector3(Screen.width, 0, 0);
            }
            StartCoroutine(SmoothMove(choosenOne.position, titik[currentPage-1].position, easing, choosenOne));
            StartCoroutine(SmoothMove(transform.position, newLocation, easing, transform));
            panelLocation = newLocation;
        }else{
            StartCoroutine(SmoothMove(transform.position, panelLocation, easing, transform));
        }
    }
    IEnumerator SmoothMove(Vector3 startpos, Vector3 endpos, float seconds, Transform obyek){
        float t = 0f;
        while(t <= 1.0){
            t += Time.deltaTime / seconds;
            obyek.position = Vector3.Lerp(startpos, endpos, Mathf.SmoothStep(0f, 1f, t));
            yield return null;
        }
    }
}