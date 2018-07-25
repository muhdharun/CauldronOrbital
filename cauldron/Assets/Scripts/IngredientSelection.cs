using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IngredientSelection : MonoBehaviour
{
    //Base
    int isBread = 0, isRice = 0, isNoodles = 0, isPasta = 0, isOats = 0;

    //Meat
    int isChicken = 0, isBeef = 0, isMutton = 0, isFish = 0, isPrawn = 0, isHam = 0, isSausage = 0, isBacon = 0;

    //Fruits
    int isApple = 0, isAvocado = 0, isBanana = 0, isBerries = 0, isCherry = 0, isCoconut = 0, isDate = 0,
        isDurian = 0, isGrape = 0, isLemon = 0, isMango = 0, isMelon = 0, isOrange = 0, isStrawberry = 0;

    //Vegaetables
    int isAsparagus = 0, isBroccoli = 0, isCabbage = 0, isCauliflower = 0, isCelery = 0, isLettuce = 0, isOnion = 0,
        isPeas = 0, isGarlic = 0, isSpinach = 0, isCarrot = 0, isGinger = 0, isTomato = 0, isPotato = 0, isCucumber = 0,
        isScallion = 0, isChili = 0;

    //Spreads
    int isPeanutButter = 0, isChocolateSpread = 0, isJam = 0;

    //Misc
    int isSalt = 0, isPepper = 0, isOil = 0, isFlour = 0, isCheese = 0, isMilk = 0, isEggs = 0,
        isBakingPowder = 0, isSugar = 0, isVinegar = 0, isButter = 0, isCookies = 0, isIceCream = 0, isChocolate = 0,
        isBreadCrumbs = 0, isChiliSauce = 0, isBBQSauce = 0, isKetchup = 0, isSoySauce = 0;

    public static List<string> UserIngredients;

    private void Start()
    {
        UserIngredients = new List<string>();
    }

    public void FinalNextButtonPressed()
    {
        //SceneManager.LoadSceneAsync("Results");
        SceneManager.LoadSceneAsync("CauldronAnimation");
        
    }

    public void BackButtonOnBasePagePressed()
    {
        SceneManager.LoadSceneAsync("TypeOfMeal");
    }

    public void HaveBread()
    {
        if (isBread == 0)
        {
            isBread++;
            UserIngredients.Add("Bread");
            //Debug.Log("Bread added");
        }
        else
        {
            isBread--;
            UserIngredients.Remove("Bread");
            //Debug.Log("Removing bread...");
        }
    }
    public void HaveRice()
    {
        if (isRice == 0)
        {
            isRice++;
            UserIngredients.Add("Rice");
            //Debug.Log("Rice added");
        }
        else
        {
            isRice--;
            UserIngredients.Remove("Rice");
            //Debug.Log("Removing Rice...");
        }
    }
    public void HaveNoodles()
    {
        if (isNoodles == 0)
        {
            isNoodles++;
            UserIngredients.Add("Noodles");
            //Debug.Log("Noodles added");
        }
        else
        {
            isNoodles--;
            UserIngredients.Remove("Noodles");
            //Debug.Log("Removing Noodles...");
        }
    }
    public void HavePasta()
    {
        if (isPasta == 0)
        {
            isPasta++;
            UserIngredients.Add("Pasta");
            //Debug.Log("Pasta added");
        }
        else
        {
            isPasta--;
            UserIngredients.Remove("Pasta");
            //Debug.Log("Removing Pasta...");
        }
    }
    public void HaveOats()
    {
        if (isOats == 0)
        {
            isOats++;
            UserIngredients.Add("Oats");
            //Debug.Log("Oats added");
        }
        else
        {
            isOats--;
            UserIngredients.Remove("Oats");
            //Debug.Log("Removing Oats...");
        }
    }
    public void HaveChicken()
    {
        if (isChicken == 0)
        {
            isChicken++;
            UserIngredients.Add("Chicken");
            //Debug.Log("Chicken added");
        }
        else
        {
            isChicken--;
            UserIngredients.Remove("Chicken");
            //Debug.Log("Removing Chicken...");
        }
    }
    public void HaveBeef()
    {
        if (isBeef == 0)
        {
            isBeef++;
            UserIngredients.Add("Beef");
            //Debug.Log("Beef added");
        }
        else
        {
            isBeef--;
            UserIngredients.Remove("Beef");
            //Debug.Log("Removing Beef...");
        }
    }
    public void HaveMutton()
    {
        if (isMutton == 0)
        {
            isMutton++;
            UserIngredients.Add("Mutton");
            //Debug.Log("Mutton added");
        }
        else
        {
            isMutton--;
            UserIngredients.Remove("Mutton");
            //Debug.Log("Removing Mutton...");
        }
    }
    public void HaveFish()
    {
        if (isFish == 0)
        {
            isFish++;
            UserIngredients.Add("Fish");
            //Debug.Log("Fish added");
        }
        else
        {
            isFish--;
            UserIngredients.Remove("Fish");
            //Debug.Log("Removing Fish...");
        }
    }
    public void HavePrawn()
    {
        if (isPrawn == 0)
        {
            isPrawn++;
            UserIngredients.Add("Prawn");
            //Debug.Log("Prawn added");
        }
        else
        {
            isPrawn--;
            UserIngredients.Remove("Prawn");
            //Debug.Log("Removing Prawn...");
        }
    }
    public void HaveHam()
    {
        if (isHam == 0)
        {
            isHam++;
            UserIngredients.Add("Ham");
            //Debug.Log("Ham added");
        }
        else
        {
            isHam--;
            UserIngredients.Remove("Ham");
            //Debug.Log("Removing Ham...");
        }
    }
    public void HaveSausage()
    {
        if (isSausage == 0)
        {
            isSausage++;
            UserIngredients.Add("Sausage");
            //Debug.Log("Sausage added");
        }
        else
        {
            isSausage--;
            UserIngredients.Remove("Sausage");
            //Debug.Log("Removing Sausage...");
        }
    }
    public void HaveBacon()
    {
        if (isBacon == 0)
        {
            isBacon++;
            UserIngredients.Add("Bacon");
            //Debug.Log("Bacon added");
        }
        else
        {
            isBacon--;
            UserIngredients.Remove("Bacon");
            //Debug.Log("Removing Bacon...");
        }
    }
    public void HaveApple()
    {
        if (isApple == 0)
        {
            isApple++;
            UserIngredients.Add("Apple");
            //Debug.Log("Apple added");
        }
        else
        {
            isApple--;
            UserIngredients.Remove("Apple");
            //Debug.Log("Removing Apple...");
        }
    }
    public void HaveAvocado()
    {
        if (isAvocado == 0)
        {
            isAvocado++;
            UserIngredients.Add("Avocado");
            //Debug.Log("Avocado added");
        }
        else
        {
            isAvocado--;
            UserIngredients.Remove("Avocado");
            //Debug.Log("Removing Avocado...");
        }
    }
    public void HaveBanana()
    {
        if (isBanana == 0)
        {
            isBanana++;
            UserIngredients.Add("Banana");
            //Debug.Log("Banana added");
        }
        else
        {
            isBanana--;
            UserIngredients.Remove("Banana");
            //Debug.Log("Removing Banana...");
        }
    }
    public void HaveBerries()
    {
        if (isBerries == 0)
        {
            isBerries++;
            UserIngredients.Add("Berries");
            //Debug.Log("Berries added");
        }
        else
        {
            isBerries--;
            UserIngredients.Remove("Berries");
            //Debug.Log("Removing Berries...");
        }
    }
    public void HaveCherry()
    {
        if (isCherry == 0)
        {
            isCherry++;
            UserIngredients.Add("Cherry");
            //Debug.Log("Cherry added");
        }
        else
        {
            isCherry--;
            UserIngredients.Remove("Cherry");
            //Debug.Log("Removing Cherry...");
        }
    }
    public void HaveCoconut()
    {
        if (isCoconut == 0)
        {
            isCoconut++;
            UserIngredients.Add("Coconut");
            //Debug.Log("Coconut added");
        }
        else
        {
            isCoconut--;
            UserIngredients.Remove("Coconut");
            //Debug.Log("Removing Coconut...");
        }
    }
    public void HaveDate()
    {
        if (isDate == 0)
        {
            isDate++;
            UserIngredients.Add("Date");
            //Debug.Log("Date added");
        }
        else
        {
            isDate--;
            UserIngredients.Remove("Date");
            //Debug.Log("Removing Date...");
        }
    }
    public void HaveDurian()
    {
        if (isDurian == 0)
        {
            isDurian++;
            UserIngredients.Add("Durian");
            //Debug.Log("Durian added");
        }
        else
        {
            isDurian--;
            UserIngredients.Remove("Durian");
            //Debug.Log("Removing Durian...");
        }
    }
    public void HaveGrape()
    {
        if (isGrape == 0)
        {
            isGrape++;
            UserIngredients.Add("Grape");
            //Debug.Log("Grape added");
        }
        else
        {
            isGrape--;
            UserIngredients.Remove("Grape");
            //Debug.Log("Removing Grape...");
        }
    }
    public void HaveLemon()
    {
        if (isLemon == 0)
        {
            isLemon++;
            UserIngredients.Add("Lemon");
            //Debug.Log("Lemon added");
        }
        else
        {
            isLemon--;
            UserIngredients.Remove("Lemon");
            //Debug.Log("Removing Lemon...");
        }
    }
    public void HaveMango()
    {
        if (isMango == 0)
        {
            isMango++;
            UserIngredients.Add("Mango");
            //Debug.Log("Mango added");
        }
        else
        {
            isMango--;
            UserIngredients.Remove("Mango");
            //Debug.Log("Removing Mango...");
        }
    }
    public void HaveMelon()
    {
        if (isMelon == 0)
        {
            isMelon++;
            UserIngredients.Add("Melon");
            //Debug.Log("Melon added");
        }
        else
        {
            isMelon--;
            UserIngredients.Remove("Melon");
            //Debug.Log("Removing Melon...");
        }
    }
    public void HaveOrange()
    {
        if (isOrange == 0)
        {
            isOrange++;
            UserIngredients.Add("Orange");
            //Debug.Log("Orange added");
        }
        else
        {
            isOrange--;
            UserIngredients.Remove("Orange");
            //Debug.Log("Removing Orange...");
        }
    }
    public void HaveStrawberry()
    {
        if (isStrawberry == 0)
        {
            isStrawberry++;
            UserIngredients.Add("Strawberry");
            //Debug.Log("Strawberry added");
        }
        else
        {
            isStrawberry--;
            UserIngredients.Remove("Strawberry");
            //Debug.Log("Removing Strawberry...");
        }
    }
    public void HaveAsparagus()
    {
        if (isAsparagus == 0)
        {
            isAsparagus++;
            UserIngredients.Add("Asparagus");
            //Debug.Log("Asparagus added");
        }
        else
        {
            isAsparagus--;
            UserIngredients.Remove("Asparagus");
            //Debug.Log("Removing Asparagus...");
        }
    }
    public void HaveBroccoli()
    {
        if (isBroccoli == 0)
        {
            isBroccoli++;
            UserIngredients.Add("Broccoli");
            //Debug.Log("Broccoli added");
        }
        else
        {
            isBroccoli--;
            UserIngredients.Remove("Broccoli");
            //Debug.Log("Removing Broccoli...");
        }
    }
    public void HaveCabbage()
    {
        if (isCabbage == 0)
        {
            isCabbage++;
            UserIngredients.Add("Cabbage");
            //Debug.Log("Cabbage added");
        }
        else
        {
            isCabbage--;
            UserIngredients.Remove("Cabbage");
            //Debug.Log("Removing Cabbage...");
        }
    }
    public void HaveCauliflower()
    {
        if (isCauliflower == 0)
        {
            isCauliflower++;
            UserIngredients.Add("Cauliflower");
            //Debug.Log("Cauliflower added");
        }
        else
        {
            isCauliflower--;
            UserIngredients.Remove("Cauliflower");
            //Debug.Log("Removing Cauliflower...");
        }
    }
    public void HaveCelery()
    {
        if (isCelery == 0)
        {
            isCelery++;
            UserIngredients.Add("Celery");
            //Debug.Log("Celery added");
        }
        else
        {
            isCelery--;
            UserIngredients.Remove("Celery");
            //Debug.Log("Removing Celery...");
        }
    }
    public void HaveLettuce()
    {
        if (isLettuce == 0)
        {
            isLettuce++;
            UserIngredients.Add("Lettuce");
            //Debug.Log("Lettuce added");
        }
        else
        {
            isLettuce--;
            UserIngredients.Remove("Lettuce");
            //Debug.Log("Removing Lettuce...");
        }
    }
    public void HaveOnion()
    {
        if (isOnion == 0)
        {
            isOnion++;
            UserIngredients.Add("Onion");
            //Debug.Log("Onion added");
        }
        else
        {
            isOnion--;
            UserIngredients.Remove("Onion");
            //Debug.Log("Removing Onion...");
        }
    }
    public void HavePeas()
    {
        if (isPeas == 0)
        {
            isPeas++;
            UserIngredients.Add("Peas");
            //Debug.Log("Peas added");
        }
        else
        {
            isPeas--;
            UserIngredients.Remove("Peas");
            //Debug.Log("Removing Peas...");
        }
    }
    public void HaveGarlic()
    {
        if (isGarlic == 0)
        {
            isGarlic++;
            UserIngredients.Add("Garlic");
            //Debug.Log("Garlic added");
        }
        else
        {
            isGarlic--;
            UserIngredients.Remove("Garlic");
            //Debug.Log("Removing Garlic...");
        }
    }
    public void HaveSpinach()
    {
        if (isSpinach == 0)
        {
            isSpinach++;
            UserIngredients.Add("Spinach");
            //Debug.Log("Spinach added");
        }
        else
        {
            isSpinach--;
            UserIngredients.Remove("Spinach");
            //Debug.Log("Removing Spinach...");
        }
    }
    public void HaveCarrot()
    {
        if (isCarrot == 0)
        {
            isCarrot++;
            UserIngredients.Add("Carrot");
            //Debug.Log("Carrot added");
        }
        else
        {
            isCarrot--;
            UserIngredients.Remove("Carrot");
            //Debug.Log("Removing Carrot...");
        }
    }
    public void HaveGinger()
    {
        if (isGinger == 0)
        {
            isGinger++;
            UserIngredients.Add("Ginger");
            //Debug.Log("Ginger added");
        }
        else
        {
            isGinger--;
            UserIngredients.Remove("Ginger");
            //Debug.Log("Removing Ginger...");
        }
    }
    public void HaveTomato()
    {
        if (isTomato == 0)
        {
            isTomato++;
            UserIngredients.Add("Tomato");
            //Debug.Log("Tomato added");
        }
        else
        {
            isTomato--;
            UserIngredients.Remove("Tomato");
            //Debug.Log("Removing Tomato...");
        }
    }
    public void HavePotato()
    {
        if (isPotato == 0)
        {
            isPotato++;
            UserIngredients.Add("Potato");
            //Debug.Log("Potato added");
        }
        else
        {
            isPotato--;
            UserIngredients.Remove("Potato");
            //Debug.Log("Removing Potato...");
        }
    }
    public void HaveCucumber()
    {
        if (isCucumber == 0)
        {
            isCucumber++;
            UserIngredients.Add("Cucumber");
            //Debug.Log("Cucumber added");
        }
        else
        {
            isCucumber--;
            UserIngredients.Remove("Cucumber");
            //Debug.Log("Removing Cucumber...");
        }
    }
    public void HavePeanutButter()
    {
        if (isPeanutButter == 0)
        {
            isPeanutButter++;
            UserIngredients.Add("PeanutButter");
            //Debug.Log("PeanutButter added");
        }
        else
        {
            isPeanutButter--;
            UserIngredients.Remove("PeanutButter");
            //Debug.Log("Removing PeanutButter...");
        }
    }
    public void HaveChocolateSpread()
    {
        if (isChocolateSpread == 0)
        {
            isChocolateSpread++;
            UserIngredients.Add("ChocolateSpread");
            //Debug.Log("ChocolateSpread added");
        }
        else
        {
            isChocolateSpread--;
            UserIngredients.Remove("ChocolateSpread");
            //Debug.Log("Removing ChocolateSpread...");
        }
    }
    public void HaveJam()
    {
        if (isJam == 0)
        {
            isJam++;
            UserIngredients.Add("Jam");
            //Debug.Log("Jam added");
        }
        else
        {
            isCucumber--;
            UserIngredients.Remove("Jam");
            //Debug.Log("Removing Jam...");
        }
    }
    public void HaveSalt()
    {
        if (isSalt == 0)
        {
            isSalt++;
            UserIngredients.Add("Salt");
            //Debug.Log("Salt added");
        }
        else
        {
            isSalt--;
            UserIngredients.Remove("Salt");
            //Debug.Log("Removing Salt...");
        }
    }
    public void HavePepper()
    {
        if (isPepper == 0)
        {
            isPepper++;
            UserIngredients.Add("Pepper");
            //Debug.Log("Pepper added");
        }
        else
        {
            isPepper--;
            UserIngredients.Remove("Pepper");
            //Debug.Log("Removing Pepper...");
        }
    }
    public void HaveOil()
    {
        if (isOil == 0)
        {
            isOil++;
            UserIngredients.Add("Oil");
            //Debug.Log("Oil added");
        }
        else
        {
            isOil--;
            UserIngredients.Remove("Oil");
            //Debug.Log("Removing Oil...");
        }
    }
    public void HaveFlour()
    {
        if (isFlour == 0)
        {
            isFlour++;
            UserIngredients.Add("Flour");
            //Debug.Log("Flour added");
        }
        else
        {
            isFlour--;
            UserIngredients.Remove("Flour");
            //Debug.Log("Removing Flour...");
        }
    }
    public void HaveCheese()
    {
        if (isCheese == 0)
        {
            isCheese++;
            UserIngredients.Add("Cheese");
            //Debug.Log("Cheese added");
        }
        else
        {
            isCheese--;
            UserIngredients.Remove("Cheese");
            //Debug.Log("Removing Cheese...");
        }
    }
    public void HaveMilk()
    {
        if (isMilk == 0)
        {
            isMilk++;
            UserIngredients.Add("Milk");
            //Debug.Log("Milk added");
        }
        else
        {
            isMilk--;
            UserIngredients.Remove("Milk");
            //Debug.Log("Removing Milk...");
        }
    }
    public void HaveEggs()
    {
        if (isEggs == 0)
        {
            isEggs++;
            UserIngredients.Add("Eggs");
            //Debug.Log("Eggs added");
        }
        else
        {
            isEggs--;
            UserIngredients.Remove("Eggs");
            //Debug.Log("Removing Eggs...");
        }
    }
    public void HaveBakingPowder()
    {
        if (isBakingPowder == 0)
        {
            isBakingPowder++;
            UserIngredients.Add("BakingPowder");
            //Debug.Log("BakingPowder added");
        }
        else
        {
            isSugar--;
            UserIngredients.Remove("BakingPowder");
            //Debug.Log("Removing BakingPowder...");
        }
    }
    public void HaveVinegar()
    {
        if (isVinegar == 0)
        {
            isVinegar++;
            UserIngredients.Add("Vinegar");
            //Debug.Log("Vinegar added");
        }
        else
        {
            isVinegar--;
            UserIngredients.Remove("Vinegar");
            //Debug.Log("Removing Vinegar...");
        }
    }
    public void HaveButter()
    {
        if (isButter == 0)
        {
            isButter++;
            UserIngredients.Add("Butter");
            //Debug.Log("Butter added");
        }
        else
        {
            isButter--;
            UserIngredients.Remove("Butter");
            //Debug.Log("Removing Butter...");
        }
    }
    public void HaveSugar()
    {
        if (isSugar == 0)
        {
            isSugar++;
            UserIngredients.Add("Sugar");
            //Debug.Log("Sugar added");
        }
        else
        {
            isSugar--;
            UserIngredients.Remove("Sugar");
            //Debug.Log("Removing Sugar...");
        }
    }
    public void HaveCookies()
    {
        if (isCookies == 0)
        {
            isCookies++;
            UserIngredients.Add("Cookies");
            //Debug.Log("Cookies added");
        }
        else
        {
            isCookies--;
            UserIngredients.Remove("Cookies");
            //Debug.Log("Removing Cookies...");
        }
    }
    public void HaveIceCream()
    {
        if (isIceCream == 0)
        {
            isIceCream++;
            UserIngredients.Add("IceCream");
            //Debug.Log("IceCream added");
        }
        else
        {
            isCookies--;
            UserIngredients.Remove("IceCream");
            //Debug.Log("Removing IceCream...");
        }
    }
    public void HaveChocolate()
    {
        if (isChocolate == 0)
        {
            isChocolate++;
            UserIngredients.Add("Chocolate");
            //Debug.Log("Chocolate added");
        }
        else
        {
            isChocolate--;
            UserIngredients.Remove("Chocolate");
            //Debug.Log("Removing Chocolate...");
        }
    }

    public void HaveScallion()
    {
        if (isScallion == 0)
        {
            isScallion++;
            UserIngredients.Add("Scallion");
            
        }
        else
        {
            isScallion--;
            UserIngredients.Remove("Scallion");
            
        }
    }

    public void HaveChili()
    {
        if (isChili == 0)
        {
            isChili++;
            UserIngredients.Add("Chili");
            //Debug.Log("Chocolate added");
        }
        else
        {
            isChili--;
            UserIngredients.Remove("Chili");
            //Debug.Log("Removing Chocolate...");
        }
    }

    public void HaveBreadCrumbs()
    {
        if (isBreadCrumbs == 0)
        {
            isBreadCrumbs++;
            UserIngredients.Add("BreadCrumbs");
            //Debug.Log("Chocolate added");
        }
        else
        {
            isBreadCrumbs--;
            UserIngredients.Remove("BreadCrumbs");
            //Debug.Log("Removing Chocolate...");
        }
    }

    public void HaveChiliSauce()
    {
        if (isChiliSauce == 0)
        {
            isChiliSauce++;
            UserIngredients.Add("ChiliSauce");
            
        }
        else
        {
            isChiliSauce--;
            UserIngredients.Remove("ChiliSauce");
            
        }
    }

    public void HaveBBQSauce()
    {
        if (isBBQSauce == 0)
        {
            isBBQSauce++;
            UserIngredients.Add("BBQSauce");
            
        }
        else
        {
            isBBQSauce--;
            UserIngredients.Remove("BBQSauce");
            
        }
    }

    public void HaveKetchup()
    {
        if (isKetchup == 0)
        {
            isKetchup++;
            UserIngredients.Add("Ketchup");
            
        }
        else
        {
            isChili--;
            UserIngredients.Remove("Ketchup");
            
        }
    }
    public void HaveSoySauce()
    {
        if (isSoySauce == 0)
        {
            isSoySauce++;
            UserIngredients.Add("SoySauce");

        }
        else
        {
            isSoySauce--;
            UserIngredients.Remove("SoySauce");

        }
    }
}