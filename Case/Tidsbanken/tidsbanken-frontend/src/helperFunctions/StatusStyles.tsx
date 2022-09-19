export function statusStyle(status: string) {

    const approved = {
      backgroundColor: "#aaaaff",
      color: "#000",
    };

    const pending = {
      backgroundColor: "#f0f0f0",
      color: "#000",
    };

    const denied = {
      backgroundColor: "#ffaaaa",
      color: "#000",
    }

    if (status == "Denied") {
      return denied
    }
    if (status == "Approved") {
      return approved
    }
    if (status == "Pending"){
      return pending;
    }
    return {
      backgroundColor: "#888888",
      color: "#fff",
    }
  };