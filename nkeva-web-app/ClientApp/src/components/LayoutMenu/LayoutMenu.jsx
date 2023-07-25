import React from "react";
import cl from "./.module.css";
import { Outlet, useNavigate } from "react-router-dom";
import Space from "../Space/Space";

const LayoutMenu = () => {

    const navigate = useNavigate();

    const langMenuRef = React.useRef();

    const [isLangMenuVisible, setLangMenuVisibility] = React.useState(false);

    function getTitle() {
        switch (window.location.pathname) {
            case "/account":
                return "My account";
            case "/account/courses":
                return "Courses";
            case "/account/schedule":
                return "Schedule";
            case "/account/chats":
                return "Chats";
            case "/account/grades":
                return "Grades";
            case "/account/anime":
                return "Anime";
            case "/account/friends":
                return "Friends";
            default:
                return "UNDEFINED LOCATION";
        }
    }

    function windowClickEvent(event) {
        if (isLangMenuVisible && !langMenuRef.current.contains(event.target)) {
            setLangMenuVisibility(false);
        }
    }

    React.useEffect(() => {
        window.addEventListener("click", windowClickEvent);

        return () => {
            window.removeEventListener("click", windowClickEvent);
        };
    });

    return (
        <div className={cl.main}>
            <aside className={cl.left_menu}>
                <Space height="24px" />
                <div className={cl.web_header}>
                    <img className={cl.logo} alt="Nkeva logo" />
                    <h1 className={cl.logo_text}>School</h1>
                </div>
                <Space height="8vh" />
                <div className={cl.page_list}>
                    <div className={`${cl.page} ${cl.account_page} ${window.location.pathname === '/account' ? cl.current_page : ""}`}
                        onClick={() => navigate("/account")}>
                        <div className={cl.locator}></div>
                        <img alt="account" />
                        <span>My account</span>
                    </div>
                    <div className={`${cl.page} ${cl.courses_page} ${window.location.pathname === '/account/courses' ? cl.current_page : ""}`}
                        onClick={() => navigate("/account/courses")}>
                        <div className={cl.locator}></div>
                        <img alt="course" />
                        <span>Courses</span>
                    </div>
                    <div className={`${cl.page} ${cl.schedule_page} ${window.location.pathname === '/account/schedule' ? cl.current_page : ""}`}
                        onClick={() => navigate("/account/schedule")}>
                        <div className={cl.locator}></div>
                        <img alt="schedule" />
                        <span>Schedule</span>
                    </div>
                    <div className={`${cl.page} ${cl.chats_page} ${window.location.pathname === '/account/chats' ? cl.current_page : ""}`}
                        onClick={() => navigate("/account/chats")}>
                        <div className={cl.locator}></div>
                        <img alt="chat" />
                        <span>Chats</span>
                    </div>
                    <div className={`${cl.page} ${cl.grades_page} ${window.location.pathname === '/account/grades' ? cl.current_page : ""}`}
                        onClick={() => navigate("/account/grades")}>
                        <div className={cl.locator}></div>
                        <img alt="grades" />
                        <span>Grades</span>
                    </div>
                    <div className={`${cl.page} ${cl.anime_page} ${window.location.pathname === '/account/anime' ? cl.current_page : ""}`}
                        onClick={() => navigate("/account/anime")}>
                        <div className={cl.locator}></div>
                        <img alt="anime" />
                        <span>Anime</span>
                    </div>
                    <div className={`${cl.page} ${cl.friends_page} ${window.location.pathname === '/account/friends' ? cl.current_page : ""}`}
                        onClick={() => navigate("/account/friends")}>
                        <div className={cl.locator}></div>
                        <img alt="friends" />
                        <span>Friends</span>
                    </div>
                </div>
            </aside>
            <div className={cl.content}>
                <Space height="90px" />
                <header className={cl.top_menu}>
                    <div className={cl.page_header}>
                        <h1>{getTitle()}</h1>
                    </div>
                    <div className={cl.top_menu_options}>
                        <div className={cl.lang} ref={langMenuRef}>
                            <div className={cl.current_lang} onClick={() => setLangMenuVisibility(prev => !prev)}>
                                <span className={cl.current_lang_name}>English (EN)</span>
                            </div>
                            <div className={cl.lang_menu} style={{ display: isLangMenuVisible ? 'block' : 'none' }}>
                                <p className={`${cl.lang_name} ${cl.en_lang_name}`} onClick={() => setLangMenuVisibility(false)}>English (EN)</p>
                                <p className={`${cl.lang_name} ${cl.ua_lang_name}`} onClick={() => setLangMenuVisibility(false)}>Українська (UA)</p>
                            </div>
                        </div>
                        <Space width="5px" />
                        <div className={cl.wall}></div>
                        <Space width="12px" />
                        <img className={cl.notifications} alt="notifications" />
                        <Space width="10px" />
                        <img className={cl.leave} alt="leave" />
                        <Space width="10px" />
                        <img className={cl.profile} alt="profile" />
                        <Space width="10px" />
                        <img className={cl.drop_down} alt="drop down menu" />
                    </div>
                </header>
                <Outlet />
            </div>
        </div>
    );
}

export default LayoutMenu;