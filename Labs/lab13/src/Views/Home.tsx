import React from "react";

const Home: React.FC = () => {
    return (
        <div className="container mt-5">
            <h1 className="display-4">Завдання</h1>
            <p className="lead">Створити веб застосунок (ASP.NET Core MVC), що задовольнятиме наступним вимогам:</p>
            <ul className="list-group list-group-flush">
                <li className="list-group-item">
                    <strong>1.</strong> Складається з двох проектів:
                    <ul>
                        <li>a. Безпосередньо веб додаток</li>
                        <li>b. Бібліотека класів, що дає змогу запускати практичні 1, 2 або 3</li>
                    </ul>
                </li>
                <li className="list-group-item">
                    <strong>2.</strong> Розгортання виконати на операційній системі Linux (Ubuntu/Debian) за допомогою
                    віртуальної машини
                </li>
                <li className="list-group-item">
                    <strong>3.</strong> Має наступний інтерфейс:
                    <ul>
                        <li>a. Сторінка вітання з описом роботи</li>
                        <li>b. Сторінка логіну, реєстрації та профілю користувача.</li>
                        <li>
                            c. 3 сторінки для кожної підпрограми з полями для вводу та виводу, з описом того, що робить
                            підпрограма
                        </li>
                        <li>d. Доступ до сторінок з підпрограмами можливий після авторизації</li>
                    </ul>
                </li>
                <li className="list-group-item">
                    <strong>4.</strong> Сторінка реєстрації має дозволяти ввести, щонайменше наступні поля:
                    <ul>
                        <li>a. Ім&apos;я користувача (50 символів, унікальне)</li>
                        <li>b. ФІО (500 символів)</li>
                        <li>
                            c. Пароль та підтвердження паролю (однакові, щонайменше 1 цифра, 1 знак, 1 велика літера, не
                            менше 8 символів, не більше 16)
                        </li>
                        <li>d. Телефон (формат Україна)</li>
                        <li>e. Електронна адреса RFC 822 (посилання на стандарт)</li>
                    </ul>
                </li>
                <li className="list-group-item">
                    <strong>5.</strong> Сторінка профілю не має можливості редагування, тільки відображає інформацію, що
                    введена при реєстрації
                </li>
                <li className="list-group-item">
                    <strong>6.</strong> Для авторизації та аутентифікації слід використати будь-який сервер, що реалізує
                    OAuth2:
                    <ul>
                        <li>
                            a.{" "}
                            <a
                                href="https://identityserver4.readthedocs.io/en/latest/"
                                target="_blank"
                                rel="noopener noreferrer"
                            >
                                IdentityServer4
                            </a>
                        </li>
                        <li>
                            b.{" "}
                            <a
                                href="https://www.okta.com/pricing/#customer-identity-products"
                                target="_blank"
                                rel="noopener noreferrer"
                            >
                                Okta
                            </a>
                        </li>
                        <li>c. Google Identity</li>
                        <li>d. Інші варіанти, що реалізують OAuth2</li>
                    </ul>
                </li>
                <li className="list-group-item">
                    <strong>7.</strong> Під час захисту потрібно буде показати розгорнуті віртуальні машини, сервер
                    авторизації і що локальні налаштування працюють.
                </li>
                <li className="list-group-item">
                    <strong>8.</strong> Всі скрипти або інші команди, що слід виконати для розгортання застосунку, слід
                    додати до репозиторію.
                </li>
            </ul>
        </div>
    );
};

export default Home;