//getDays(new Date(2019, 06, 01),new Date(2019, 06, 20))

const getDays = (date1, date2) => {
    //subtract the dates
    const difference = date2.getTime() - date1.getTime();
    //Math.ceil gives back the smalles integer
    let days = Math.ceil(difference / (1000 * 3600 * 24));
    console.log("From " + date1 + " to " + date2 + " it is " +  days + ' days between the two dates');
}

getDays(
    new Date("June 14, 2019"),
    new Date("June 20, 2019")
    );

getDays(
        new Date("December 29, 2018"),
        new Date("January 1, 2019")
      );

getDays(
        new Date("July 20, 2019"),
        new Date("July 30, 2019")
      );

getDays(
        new Date("July 20, 2019"),
        new Date("July 30, 2022")
      );
