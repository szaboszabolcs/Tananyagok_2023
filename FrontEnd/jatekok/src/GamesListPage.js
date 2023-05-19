import axios from "axios";
import { useEffect, useState } from "react";
import { NavLink} from "react-router-dom";

export function GamesListPage() {
    const [termekeks, setTermekek] = useState([]);
    const [isFetchPending, setFetchPending ] = useState(false);

    useEffect(() => {
        setFetchPending(true);
        (async() => {
            try {
                const jatekok = await axios.get("https://localhost:5001/api/Jatekok");
                setTermekek(jatekok.data);
            } catch (err) {
                console.log(err);
            }
            finally {
                setFetchPending(false);
            }
        })();
    }, []);

    return (
        <div className="p-5 m-auto text-center content bg-ivory">
            {isFetchPending ? (
                <div className="spinner-border"></div>
            ) : (
              <div>
                <h3>Játékok</h3>
                {termekeks.map((termekek) => (
                    <NavLink key={termekek.id} to={"/jatek/" + termekek.id}>
                        <div className="card col-sm-3 d-inline-block m-3 p-2">
                            <h5 className="text-muted">{termekek.nev}</h5>
                            <div>{termekek.ar} Ft</div>
                            <div className="card-body">
                            <img
                                className="img-fluid"
                                style={{ maxHeight: 200 }}
                                src={termekek.kepUrl ? termekek.kepUrl : "https://via.placeholder.com/400x800"}
                            />
                            </div>
                        </div>
                    </NavLink>
                ))}
              </div>
            )}
        </div>
    )
}