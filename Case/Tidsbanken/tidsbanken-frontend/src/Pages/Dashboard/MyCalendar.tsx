import { Calendar, momentLocalizer } from "react-big-calendar";
import moment from "moment";
import { selfReadVacationRequestDTO } from '../../models/DTOs';
import "react-big-calendar/lib/css/react-big-calendar.css";
import "react-datepicker/dist/react-datepicker.css";
import { toDate } from "../../helperFunctions/toDate";
import { useNavigate } from "react-router-dom";
import { statusStyle } from "../../helperFunctions/StatusStyles";

interface AllEvent {
    allEvents: selfReadVacationRequestDTO[];
}

const MyCalendar = ({ allEvents }: AllEvent) => {
    const localizer = momentLocalizer(moment);

    function convert(events: selfReadVacationRequestDTO[]): any[] {
        let output = events?.map(convertDtoToObject);
        if (output !== undefined) {
            return output!;
        }
        return [];
    }

    function convertDtoToObject(event: selfReadVacationRequestDTO) {
        let output = {
            title: event.title,
            start: toDate(event.startDate),
            end: toDate(event.endDate),
            ineligiblePeriod: (event.status === "Approved"),
            periodId: event.id,
            status: event.status
        };

        return output;
    }

    // Styling-elements to make event color different.
    const eventStyle = (
        event: any,
    ) => {
        let status = event.status;
        return {style: statusStyle(status)};
    };

    // Date/Time formating in big-calendar.
    const formats = {
        timeGutterFormat: (date: any, culture: any, localizer: any) =>
            localizer.format(date, "HH:mm", culture),
        eventTimeRangeFormat: (date: any, culture: any, localizer: any) =>
            localizer.format(date, "HH:mm", culture),
    };

    // ---------------------------------------------
    let navigate = useNavigate();

    const handleSelected = (event: any) => {
        // Routing
        navigate("/requestDetails/" + event.periodId);
    };


    return (
        <>


            <Calendar
                localizer={localizer}
                events={convert(allEvents)}
                startAccessor="start"
                endAccessor="end"
                // The Calendar container needs a height or the calendar won't be visible
                style={{ height: "600px", margin: "50px" }}
                views={["month", "week"]}
                popup={true} // Adds ability to see lists of events if several events are made on the same day. (In Calendar on specific date, press "+2 more")
                onSelectEvent={handleSelected}
                eventPropGetter={eventStyle}
                formats={formats}
            />


        </>
    );
};

export default MyCalendar;
