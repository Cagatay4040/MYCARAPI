
import requests
from selenium import webdriver
from selenium.webdriver.common.keys import Keys
from selenium.webdriver.common.by import By
from selenium.webdriver.support.ui import Select
from webdriver_manager.chrome import ChromeDriverManager
from flask import Flask, jsonify
from flask import make_response
from flask import request
import time

def chooseColor(colorName) :

    Colors = {"beige":"//*[@id='panel_exterior_colors']/div[1]/label",
              "black":"//*[@id='panel_exterior_colors']/div[2]/label",
              "blue":"//*[@id='panel_exterior_colors']/div[3]/label",
              "brown":"//*[@id='panel_exterior_colors']/div[4]/label",
              "gold":"//*[@id='panel_exterior_colors']/div[5]/label",
              "gray":"//*[@id='panel_exterior_colors']/div[6]/label",
              "green":"//*[@id='panel_exterior_colors']/div[7]/label",
              "orange":"//*[@id='panel_exterior_colors']/div[8]/label",
              "purple":"//*[@id='panel_exterior_colors']/div[9]/label",
              "red":"//*[@id='panel_exterior_colors']/div[10]/label",
              "silver":"//*[@id='panel_exterior_colors']/div[11]/label",
              "white":"//*[@id='panel_exterior_colors']/div[12]/label",
              "yellow":"//*[@id='panel_exterior_colors']/div[13]/label"}

    colorName = colorName.lower()

    try:
        
        click_Button = browser.find_element(By.ID, "trigger_exterior_colors")

        click_Button.click()

        time.sleep(3)

        click_Button = browser.find_element(By.XPATH, Colors[colorName])

        click_Button.click()

        time.sleep(3)

        click_Button = browser.find_element(By.ID, "trigger_exterior_colors")

        click_Button.click()

    except :
        return

    return

def chooseTransmissions(transmissionsName) :

    Transmissions = {"automanual":"//*[@id='panel_transmissions']/div[1]/label",
                     "automatic":"//*[@id='panel_transmissions']/div[2]/label",
                     "cvt":"//*[@id='panel_transmissions']/div[3]/label",
                     "manual":"//*[@id='panel_transmissions']/div[4]/label",
                     "unknown":"//*[@id='panel_transmissions']/div[5]/label"}


    transmissionsName = transmissionsName.lower()

    try:
        click_Button = browser.find_element(By.ID, "trigger_transmissions")

        click_Button.click()

        time.sleep(3)

        click_Button = browser.find_element(By.XPATH, Transmissions[transmissionsName])

        click_Button.click()

        time.sleep(3)

        click_Button = browser.find_element(By.ID, "trigger_transmissions")

        click_Button.click()
    except :
        return

    return

def getCarFeatures() :

    carFeatures = {}

    car_Photo = None

    try:
        imgDiv=browser.find_element(By.ID, "swipe-index-0")
        car_Photo = imgDiv.get_attribute('src')
        carFeatures["Photo"] = car_Photo;
    except :
        imgDiv=browser.find_element(By.CLASS_NAME, "row-pic")
        car_Photo = imgDiv.get_attribute('src')
        carFeatures["Photo"] = car_Photo;
    
    #car_Photo = browser.find_element(By.XPATH,"/html/body/section/div[5]/section/div/div/div/div[2]/div/div/img[1]").text

    car_Title = browser.find_element(By.XPATH,"/html/body/section/div[5]/section/header/div[1]/h1").text

    carFeatures["Title"] = car_Title;
    
    car_Price = browser.find_element(By.XPATH,"/html/body/section/div[5]/section/header/div[2]/span").text

    carFeatures["Price"] = car_Price
    
    car_Year = browser.find_element(By.XPATH,"/html/body/section/div[5]/section/header/div[1]/h1").text

    car_Year = car_Year.split(' ')[0]

    carFeatures["Year"] = car_Year

    car_Brand = browser.find_element(By.XPATH,"/html/body/section/div[5]/section/header/div[1]/h1").text

    car_Brand = car_Brand.split(' ')[1]

    carFeatures["Brand"] = car_Brand

    car_Model = browser.find_element(By.XPATH,"/html/body/section/div[5]/section/header/div[1]/h1").text

    car_Model = car_Model.split(' ')[2]

    carFeatures["CarModel"] = car_Model

    headers = browser.find_elements(By.TAG_NAME,"dt")
    features = browser.find_elements(By.TAG_NAME,"dd")

    for x in range(0,11):
        carFeatures[headers[x].text.replace(" ","_").replace("_#","")] = features[x].text
    
    return carFeatures

def chooseBrand(brandName) :
    
    try:
        Select(browser.find_element(By.ID,"make_select")).select_by_value(str(brandName).lower())
        time.sleep(3)
    except :
        return

    return

def chooseMinYear(year) :
    
    try:
        Select(browser.find_element(By.ID,"year_year_min_select")).select_by_value(str(year))
        time.sleep(3)
    except :
        return

    return

def chooseMaxYear(year) :
    
    try:
        Select(browser.find_element(By.ID,"year_year_max_select")).select_by_value(str(year))
        time.sleep(3)
    except :
        return

    return

def getCars() :
    
    #cars = {}
    cars = []

    click_First_Car = browser.find_element(By.XPATH, "/html/body/section/div[2]/div[6]/div/div[1]/div[2]/div/div[2]/a")

    click_First_Car.click()

    for x in range(6):
        
        #cars[x] = getCarFeatures()

        cars.append(getCarFeatures());
        
        time.sleep(3)
       
        next_Button = browser.find_element(By.XPATH, "/html/body/section/div[4]/section[2]/div/div[2]/a")
        
        next_Button.click()

        time.sleep(3)

    return cars

browser = webdriver.Chrome(ChromeDriverManager().install())
browser.implicitly_wait(10)

time.sleep(5)

app = Flask(__name__)

@app.route('/cars/list', methods=['GET'])
def myServer():

    with requests.get("https://www.cars.com/for-sale/searchresults.action") as res:
        if res.status_code == 200:
            browser.get("https://www.cars.com/for-sale/searchresults.action")

            if request.args.get('trans') != None:
                chooseTransmissions(request.args.get('trans'))
                time.sleep(2)

            if request.args.get('brand') != None:
                chooseBrand(request.args.get('brand'))
                time.sleep(2)

            if request.args.get('extcolor') != None:
                chooseColor(request.args.get('extcolor'))
                time.sleep(2)

            if request.args.get('year') != None:
                chooseMinYear(request.args.get('year'))
                time.sleep(2)
                chooseMaxYear(request.args.get('year'))
                time.sleep(2)

    return jsonify(getCars())

@app.errorhandler(404)
def not_found(error):
    return make_response(jsonify({'HTTP 404 Error': 'The content you looks for does not exist. Please check your request.'}), 404)
 
if __name__ == '__main__':
    app.run(debug=True)

time.sleep(5)

browser.close()
