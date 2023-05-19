import axios from "axios";
import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";

export function GameSinglePage(props) {
    const param = useParams();
    const id = param.jatekId;
    const [termek, setTermek] = useState({});
    const [isPending, setPending] = useState(false);

    useEffect(() => {
        setPending(true);
        (async () => {
            try
            {
                const jatek = await axios.get(`https://localhost:5001/api/Jatekok/${id}`);
                setTermek(jatek.data);
            }
            catch (err)
            {
                console.log(err);
            }
            finally
            {
                setPending(false);
            }
        })();
    }, []);

    return (
        <div className="p-5  m-auto text-center content bg-lavender">
            {isPending || !termek.id ? (
                <div className="spinner-border"></div>
            ) : (
              <div className="card p-3">
                <div className="card-body">
                    <h4>{termek.nev}</h4>
                    <h5 className="card-title">{termek.megjeleneseve}</h5>
                    <div className="lead">{termek.leiras}</div>
                    <p>{termek.ar} Ft</p>
                    <img
                        className="img-fluid rounded"
                        style={{ maxHeight: "450px" }}
                        src={termek.kepUrl ? termek.kepUrl : "https://via.placeholder.com/400x800"}
                />
                </div>
              </div>
            )}
        </div>
    )
}