import axios from "axios";
import { useEffect, useState } from "react";
import { NavLink } from "react-router-dom";

export function InstrumentListPage() {
    const [instruments, setInstruments] = useState([]);
    const [isFetchPending, setFetchPending] = useState(false);
    
    useEffect(() => {
        setFetchPending(true);
        (async() => {
            try {
                const hangszerek = await axios.get("https://kodbazis.hu/api/instruments", { withCredentials: true });
                setInstruments(hangszerek.data);
            } catch (err) {
                console.log(err);
            } finally {
                setFetchPending(false);
            }
        })();
      }, []);
    
    return (
        <div className="p-5  m-auto text-center content bg-ivory">
          {isFetchPending ? (
            <div className="spinner-border"></div>
          ) : (
            <div>
              <h2>Hangszerek:</h2>
              {instruments.map((instrument) => (
                <NavLink key={instrument.id} to={"/hangszer/" + instrument.id}>
                  <div className="card col-sm-3 d-inline-block m-1 p-2">
                    <h6 className="text-muted">{instrument.brand}</h6>
                    <h5 className="text-dark">{instrument.name}</h5>
                    <div>{instrument.price} ft -</div>
                    <div className="small">Készleten: {instrument.quantity} db</div>
                    <div className="card-body">
                      <img
                        className="img-fluid"
                        style={{ maxHeight: 200 }}
                        src={instrument.imageURL ? instrument.imageURL : "https://via.placeholder.com/400x800"}
                      />
                    </div>
                  </div>
                  </NavLink>
              ))}
            </div>
          )}
        </div>
      );
  }