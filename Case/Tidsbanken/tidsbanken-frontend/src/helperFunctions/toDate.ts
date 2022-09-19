export function toDate(date: string): Date {
    let dayString = date.split("T")[0];
    let args = dayString.split("-");
    return new Date(Number(args[0]), Number(args[1]) - 1, Number(args[2]));
}
export function toDateString(date: string): string {
    return toDate(date).toDateString();
}