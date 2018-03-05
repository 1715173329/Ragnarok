import json
import os
import os.path
def loadcfg():
    with open("config.json","r") as loader:
        cl_config_text = loader.read()
    return json.loads(cl_config_text)

if __name__ == "__main__":
    print (loadcfg())
    os.system("pause")

