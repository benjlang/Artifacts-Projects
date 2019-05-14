

#include <iostream>		//aids in output
#include <iomanip>		//aids in formatting
#include <string>		//aids in string reading

using namespace std;


//Function: output
//Purpose: to display the title and have the user input the function
//Input: none
//Output the function string
void titlescreen(char function[]);

//Function: input
//Purpose: to obtain three sets of values of the function
//Input: none
//Output: the coefficiants and exponant values (three sets)
void input(double &coe1, double &coe2, double &coe3, double &expo1, double &expo2, double &expo3);

//Function: input2
//Purpose: to obtain 2 sets of values for a function
//Input: none
//Output: two coefficents and two exponents
void input2(double &coe1, double &coe2, double &expo1, double &expo2);

//Function: poly
//Purpose: to calculate the derivative of a program
//Input: the coefficiants and exponant values for the polynomial
//Output: none
void poly(double coe1, double coe2, double coe3, double expo1, double expo2, double expo3);

//Function: quotient
//Purpose: to calculate the derivative using the quotient rule
//Input: the coefficents and exponents 
//Output: none
void quotient(double coe1, double coe2, double expo1, double expo2);

//Function: product
//Purpose: calaculates the derivative using the product rule
//Input: the coefficients and exponents of the function
//Output: none
void product(double coe1, double coe2, double expo1, double expo2);

//Function: determine
//Purpose: to determine which derivative rule to use
//Input: the string function
//Output: none
void determine(char function[]);





void main()
{
	char play1;		   //aids in determining user option after (choice)
	
	do
	{
	char function[30]; //origanal function
	

	system("cls");
	titlescreen(function);		//displays title and recieves function

	determine(function);		//calculates the derivative

	cout << "Press 'Y' to calculate again or 'N' to stop" << endl;
	cin >> play1;
	cin.ignore();
} while (play1 == 'y' || play1 == 'Y');




	
}

void titlescreen(char function[]) {

	
	system("cls");
	cout << "WELCOME TO THE CALCULAS CALCULATIOR!" << endl << endl << endl;		//prints title

	cout << "Please enter the function" << endl;								//has user input the function
	cin.getline(function, 30);

	

}

void input(double &coe1, double &coe2, double &coe3, double &expo1, double &expo2, double &expo3) {

	cout << "Enter the first coefficiant" << endl;			//has user input coefficiants and exponents values for the polynomial function
	cin >> coe1;
	cout << "Enter the first exponent" << endl;
	cin >> expo1;
	cout << "Enter the second coefficiant" << endl;
	cin >> coe2;
	cout << "Enter the second exponent" << endl;
	cin >> expo2;
	cout << "Enter the third coefficiant" << endl;
	cin >> coe3;
	cout << "Enter the third exponent" << endl;
	cin >> expo3;
	
}

void input2(double &coe1, double &coe2, double &expo1, double &expo2) {

	cout << "Enter the first coefficiant" << endl;			//has user input coefficiants and exponents values for product and quotient rule
	cin >> coe1;
	cout << "Enter the first exponent" << endl;
	cin >> expo1;
	cout << "Enter the second coefficiant" << endl;
	cin >> coe2;
	cout << "Enter the second exponent" << endl;
	cin >> expo2;

}

void poly(double coe1, double coe2, double coe3, double expo1, double expo2, double expo3) {


	double coeDer1;	//first coefficiant for derivative
	double coeDer2; //second coefficiant for derivative
	double coeDer3; //third coefficant for derviative

	double expoDer1;	//first exponent for derviative
	double expoDer2;	//second exponent for derviative
	double expoDer3;	//third exponent for derviative

	coeDer1 = coe1 * expo1;
	coeDer2 = coe2 * expo2;					//doing algebra to create derivative
	coeDer3 = coe3 * expo3;

	expoDer1 = expo1 - 1;
	expoDer2 = expo2 - 1;
	expoDer3 = expo3 - 1;

	cout << endl << endl;
	cout << "The derivative is:" << endl << endl;

	cout << coeDer1 << "X" << "^" << expoDer1 << " + " <<		//printing out the derivative
		coeDer2 << "X" << "^" << expoDer2 << " + " <<
		coeDer3 << "X" << "^" << expoDer3 << endl << endl;
}

void quotient(double coe1, double coe2, double expo1, double expo2) {

	double dercoe1; //first coefficiant for derivative
	double dercoe2; //second coefficiant for derivative
	double derexpo1;   //first exponent for derviative
	double derexpo2;	//second exponent for derviative

	dercoe1 = coe1 * expo1;						//doing algebra for derivative
	derexpo1 = expo1 - 1;

	dercoe2 = coe1 * expo2;
	derexpo2 = expo2 - 1;

	cout << endl << endl;
	cout << "The derivative is:" << endl << endl;

	cout << "((" << dercoe1 << "x^" << derexpo1 << ")"
		<< " * (" << coe2 << "x^" << expo2 << ")"								//printing out derivative
		<< " - (" << dercoe2 << "x^" << derexpo2 << ")"
		<< " * (" << coe1 << "x^" << expo1 << "))";
	cout << " / (" << coe2 << "x^" << expo2 << ")^2" << endl << endl;

}

void product(double coe1, double coe2, double expo1, double expo2) {

	double dercoe1; //first coefficiant for derivative
	double dercoe2; //second coefficiant for derivative
	double derexpo1;   //first exponent for derviative
	double derexpo2;	//second exponent for derviative

	dercoe1 = coe1 * expo1;					//doing algebra to calculate the derivative
	derexpo1 = expo1 - 1;

	dercoe2 = coe2 * expo2;
	derexpo2 = expo2 - 1;

	cout << endl << endl;
	cout << "The derivative is:" << endl << endl;

	cout << dercoe1 << "x^" << derexpo1 << " * " << coe2 << "x^" << expo2		//outputs the derivative
		<< " + " << dercoe2 << "x^" << derexpo2 << " * " << coe1 << "x^"
		<< expo1 << endl << endl;

}

void determine(char function[]) {

	double coe1;	//first coefficiant
	double coe2;	//second coefficiant
	double coe3;	//third coefficiant

	double expo1;		//first exponent
	double expo2;		//second exponent
	double expo3;		//third exponent

	string str(function);	//string to determine character input


	if (str.find('/') != std::string::npos)			//if function has slash, use quotient rule
	{
		input2(coe1, coe2, expo1, expo2);
		quotient(coe1, coe2, expo1, expo2);
	}
	else if (str.find('*') != std::string::npos)	//if function has multiplication sign, use product rule
	{
		input2(coe1, coe2, expo1, expo2);
		product(coe1, coe2, expo1, expo2);
	}
	else                                            //otherwise, use polynomial rule
	{
		input(coe1, coe2, coe3, expo1, expo2, expo3);
		poly(coe1, coe2, coe3, expo1, expo2, expo3);
	}


}