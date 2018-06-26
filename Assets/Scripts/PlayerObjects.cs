using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerObjects : MonoBehaviour {

	public Slider[] sliders;
	int countComputer;
	int countLaptop;
	int countMackbook;
	int countDesktop;
	int countPhone;


	public void AddCount(string countType) {
		if (countType.Equals("computer") && countComputer <= 4) {
			countComputer++;
			sliders[0].value = countComputer;
		} else if (countType.Equals("laptop") && countLaptop <= 4) {
			countLaptop++;
			sliders[1].value = countLaptop;
		} else if (countType.Equals("macbook") && countMackbook <= 4) {
			countMackbook++;
			sliders[2].value = countMackbook;
		} else if (countType.Equals("desktop") && countDesktop <= 4) {
			countDesktop++;
			sliders[3].value = countDesktop;
		} else if (countType.Equals("phone") && countPhone <= 4) {
			countPhone++;
			sliders[4].value = countPhone;
		}
	}

	public bool CanShoot() {
		return countComputer + countLaptop + countMackbook + countDesktop + countPhone > 0;
	}

	public int Shoot() {
		if (CanShoot()) {
			int idx = 0;
			if (countComputer > 0) {
				countComputer--;
				idx = 0;
			} else if (countLaptop > 0) {
				countLaptop--;
				idx = 1;
			} else if (countMackbook > 0) {
				countMackbook--;
				idx = 2;
			} else if (countDesktop > 0) {
				countDesktop--;
				idx = 3;
			} else if (countPhone > 0) {
				countPhone--;
				idx = 4;
			}
			sliders[idx].value = sliders[idx].value - 1;
			return idx;
		}
		return -1;
	}

	void InitializeCount() {
		countComputer = 0;
		countLaptop = 0;
		countMackbook = 0;
		countDesktop = 0;
		countPhone = 0;
	}
}
