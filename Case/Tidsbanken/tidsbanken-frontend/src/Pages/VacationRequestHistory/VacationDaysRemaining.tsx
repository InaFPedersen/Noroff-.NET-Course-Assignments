import React from 'react'

const VacationDaysRemaining = () => {
    //TotalVacationdays = 25;
    const TotalVacationdays = 25

    //Fetch number of approved vacationdays
    
    //VacationdaysApproved = 0; 
    let VacationDaysApproved = 0;
    //RemainingVacationDays = TotalVacationdays - VacationDaysApproved;
    let RemainingVacationDays = TotalVacationdays - VacationDaysApproved;

  return (
     <p>{RemainingVacationDays}</p> 
  )
}

export default VacationDaysRemaining